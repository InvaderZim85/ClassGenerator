using System.Text.RegularExpressions;
using ClassGenerator.Common.Enums;
using ClassGenerator.DataObjects;

namespace ClassGenerator.Common;

/// <summary>
/// Provides several helper functions
/// </summary>
internal static partial class Extensions
{
    /// <summary>
    /// Gets the regex to check if a specified value is a date / time
    /// </summary>
    /// <returns>The regex</returns>
    [GeneratedRegex(@"(\d{2}.{1}\d{2}.{1}\d{4})")]
    private static partial Regex GetDateRegex();

    /// <summary>
    /// Extracts the type of the property
    /// </summary>
    /// <param name="property">The property</param>
    /// <returns>The data type</returns>
    public static DataType GetDataType(this PropertyEntry property, out object result)
    {
        result = string.Empty; // Fallback
        var value = property.PropertyValue;
        if (string.IsNullOrEmpty(value))
            return DataType.String;

        // Try to cast the value into the desired type
        if (byte.TryParse(value, out var byteValue))
        {
            result = byteValue;
            return DataType.Byte;
        }

        if (short.TryParse(value, out var shortValue))
        {
            result = shortValue;
            return DataType.Short;
        }

        if (int.TryParse(value, out var intValue))
        {
            result = intValue;
            return DataType.Int;
        }

        if (long.TryParse(value, out var longValue))
        {
            result = longValue;
            return DataType.Long;
        }

        if (GetDateRegex().IsMatch(value) && DateTime.TryParse(value, out var dtValue))
        {
            result = dtValue;
            return DataType.DateTime;
        }

        if (double.TryParse(value, out var doubleValue))
        {
            result = doubleValue;
            return DataType.Double;
        }

        if (decimal.TryParse(value, out var decimalValue))
        {
            result = decimalValue;
            return DataType.Decimal;
        }

        if (bool.TryParse(value, out var boolValue))
        {
            result = boolValue;
            return DataType.Bool;
        }

        result = value;
        return value.Length == 1 ? DataType.Char : DataType.String; // Fallback
    }

    /// <summary>
    /// Tries to convert a string into an int. If the value is not an int, the <paramref name="fallback"/> will be returned
    /// </summary>
    /// <param name="value">The string value</param>
    /// <param name="fallback">The desired fallback (optional)</param>
    /// <returns>The converted value</returns>
    public static int ToInt(this string value, int fallback = 0)
    {
        return int.TryParse(value, out var result) ? result : fallback;
    }

    /// <summary>
    /// Checks if the string starts with a number
    /// </summary>
    /// <param name="value">The value which should be checked</param>
    /// <returns><see langword="true"/> when the value starts with a number, otherwise <see langword="false"/></returns>
    public static bool StartsWithNumber(this string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length == 0)
            return false;

        var firstChar = value[0];
        return int.TryParse(firstChar.ToString(), out _);
    }

    /// <summary>
    /// Changes the casing of the first char to lower
    /// </summary>
    /// <param name="value">The string value</param>
    /// <returns>The converted value</returns>
    public static string FirstCharToLower(this string value)
    {
        return value.ChangeFirstCharCasing(false);
    }

    /// <summary>
    /// Changes the casing of the first char to upper
    /// </summary>
    /// <param name="value">The string value</param>
    /// <returns>The converted value</returns>
    public static string FirstCharToUpper(this string value)
    {
        return value.ChangeFirstCharCasing(true);
    }

    /// <summary>
    /// Changes the casing of the first char (to upper or to lower)
    /// </summary>
    /// <param name="value">The string value</param>
    /// <param name="toUpper"><see langword="true"/> to change the first char to upper, <see langword="false"/> to change the first char to lower</param>
    /// <returns>The converted value</returns>
    private static string ChangeFirstCharCasing(this string value, bool toUpper)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        if (value.Length == 1)
            return toUpper ? value.ToUpper() : value.ToLower();

        var firstChar = toUpper 
            ? value[0].ToString().ToUpper() 
            : value[0].ToString().ToLower();

        return $"{firstChar}{value[1..]}";
    }
}