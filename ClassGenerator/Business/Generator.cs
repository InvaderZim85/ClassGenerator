using System.Globalization;
using System.Text;
using ClassGenerator.Common;
using ClassGenerator.DataObjects;
using ClassGenerator.Common.Enums;

namespace ClassGenerator.Business;

/// <summary>
/// Provides the functions to generate a class
/// </summary>
internal static class Generator
{
    /// <summary>
    /// Creates a class based on the specified file
    /// </summary>
    /// <param name="sourceFile">The path of the source file which contains the instructions</param>
    /// <param name="className">The desires class name</param>
    /// <param name="ns">The desired namespace (can be blank)</param>
    /// <param name="fileScopeNamespace"><see langword="true"/> when the file scoped namespace should be used, <see langword="false"/> when the normal namespace should be used</param>
    /// <param name="addSummary"><see langword="true"/> to add a summary, otherwise <see langword="false"/></param>
    /// <returns>The result (the class code and also the error message)</returns>
    public static async Task<GeneratorResult> GenerateClassAsync(string sourceFile, string className, string ns, bool fileScopeNamespace, bool addSummary)
    {
        // Extract the content of the file
        var properties = await ExtractFileAsync(sourceFile);

        if (!properties.Any(c => c.IsValid))
        {
            return new GeneratorResult
            {
                ErrorMessage = CreateErrorMessage()
            };
        }

        // Create the namespace (if any is specified)
        var tmpNamespace = string.IsNullOrEmpty(ns) ? "YourNamespace" : ns.Replace(" ", "_"); // Remove all spaces
        if (fileScopeNamespace)
            tmpNamespace += ";";

        var classTab = fileScopeNamespace ? string.Empty : new string(' ', 4);
        var propertyTab = new string(' ', fileScopeNamespace ? 4 : 8);
        var classCode = new StringBuilder();
        classCode.AppendLine("using System;")
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Linq;")
            .AppendLine("using System.Text;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine() // Add a "spacer"
            .AppendLine($"namespace {tmpNamespace}")
            .AppendLine(fileScopeNamespace ? string.Empty : "{"); // Add the opening bracket of the namespace (if needed)

        // Class summary
        if (addSummary)
            AddSummary(classTab, string.Empty);

        // Add the class name
        classCode.AppendLine($"{classTab}public class {className.Replace(" ", "_").FirstCharToUpper()}")
            .AppendLine($"{classTab}{{");

        // Get the valid properties and create the final value
        var tmpProperties = properties.Where(w => w.IsValid).OrderBy(o => !o.IsPrivateField).ToList();
        for (var i = 0; i < tmpProperties.Count; i++)
        {
            var property = tmpProperties[i];
            // Property summary
            if (addSummary)
                AddSummary(propertyTab, property.IsPrivateField ? "Contains the" : "Gets or sets the");

            classCode.AppendLine(CreateProperty(property, propertyTab));

            if (i < tmpProperties.Count - 1)
                classCode.AppendLine(); // Add an empty line
        }

        // Add the closing bracket of the class
        classCode.AppendLine($"{classTab}}}");

        // Add the closing bracket of the namespace (if needed)
        if (!fileScopeNamespace)
            classCode.AppendLine("}");

        return new GeneratorResult
        {
            ClassCode = classCode.ToString(),
            ErrorMessage = CreateErrorMessage()
        };

        string CreateErrorMessage()
        {
            return string.Join(Environment.NewLine,
                properties
                    .Where(w => !w.IsValid) // Only the invalid lines
                    .Select(s => $"Line: {s.Line}: {s.Info}. Original line: {s.OriginalLine}"));
        }

        void AddSummary(string tab, string text)
        {
            classCode.AppendLine($"{tab}/// <summary>")
                .AppendLine($"{tab}/// {text} TODO")
                .AppendLine($"{tab}/// </summary>");
        }
    }

    /// <summary>
    /// Extracts the content of the file
    /// </summary>
    /// <param name="sourceFile">The path of the source file</param>
    /// <returns>The list with the properties </returns>
    private static async Task<List<PropertyEntry>> ExtractFileAsync(string sourceFile)
    {
        if (string.IsNullOrWhiteSpace(sourceFile) || !File.Exists(sourceFile))
            return []; // Nothing found

        var content = await File.ReadAllLinesAsync(sourceFile);
        if (content.Length == 0)
            return []; // Empty file

        var result = new List<PropertyEntry>();

        var count = 1;
        foreach (var line in content)
        {
            var lineContent = line.Split(':', StringSplitOptions.TrimEntries);
            if (lineContent.Length >= 2)
            {
                var tmpValue = lineContent.Length > 2
                    ? string.Join(":", lineContent[1..])
                    : lineContent[1];

                var propertyName = lineContent[0];
                if (propertyName.StartsWithNumber())
                {
                    result.Add(new PropertyEntry(count, line)
                    {
                        Info = "The name of the property is not valid. The name of a property/field must not begin with a number."
                    });
                }
                else
                {
                    result.Add(new PropertyEntry(count, line)
                    {
                        PropertyName = lineContent[0],
                        PropertyValue = tmpValue
                    });
                }
            }
            else
            {
                result.Add(new PropertyEntry(count, line)
                {
                    Info = "The format of the line is not valid. Valid format: [Property name]: [Property value]"
                });
            }

            count++;
        }

        return result;
    }

    #region Helper
    /// <summary>
    /// Creates a property
    /// </summary>
    /// <param name="property">The property</param>
    /// <param name="tab">The tab size</param>
    /// <returns>The property</returns>
    private static string CreateProperty(PropertyEntry property, string tab)
    {
        // Prepare the easy values
        var name = property.IsPrivateField 
            ? $"_{property.PropertyName.Replace("_", "").FirstCharToLower()}"
            : property.PropertyName.FirstCharToUpper();
        
        // Get the data type
        var dataType = property.GetDataType(out var resultValue);
        var (tmpType, value) = dataType switch
        {
            DataType.Char => ("char", $"'{resultValue}'"),
            DataType.Byte => ("byte", resultValue.ToString() ?? string.Empty),
            DataType.Short => ("short", resultValue.ToString() ?? string.Empty),
            DataType.Int => ("int", resultValue.ToString() ?? string.Empty),
            DataType.Long => ("long", resultValue.ToString() ?? string.Empty),
            DataType.Double => ("double", ((double)resultValue).ToString(CultureInfo.InvariantCulture)),
            DataType.Decimal => ("decimal", ((decimal)resultValue).ToString(CultureInfo.InvariantCulture)),
            DataType.DateTime => ("DateTime", DateTimeToString((DateTime)resultValue)),
            DataType.Bool => ("bool", (bool)resultValue ? "true" : "false"),
            _ => ("string", $"\"{resultValue}\"")
        };

        return property.IsPrivateField
            ? $"{tab}private {tmpType} {name} = {value};"
            : $"{tab}public {tmpType} {name} {{ get; set; }} = {value};";

        static string? DateTimeToString(DateTime dateTimeValue)
        {
            return $"new DateTime({dateTimeValue.Year}, {dateTimeValue.Month}, {dateTimeValue.Day}, " +
                   $"{dateTimeValue.Hour}, {dateTimeValue.Minute}, {dateTimeValue.Second})";
        }
    }
    #endregion
}