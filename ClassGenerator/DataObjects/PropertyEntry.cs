using ClassGenerator.Common;

namespace ClassGenerator.DataObjects;

/// <summary>
/// Represents a single line of the instruction file
/// </summary>
/// <param name="line">The number of the line</param>
/// <param name="originalLine">The original line</param>
internal sealed class PropertyEntry(int line, string originalLine)
{
    /// <summary>
    /// Gets the number of the line
    /// </summary>
    public int Line => line;

    /// <summary>
    /// Gets the original line
    /// </summary>
    public string OriginalLine => originalLine;

    /// <summary>
    /// Gets or sets the name of the property
    /// </summary>
    public string PropertyName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the value of the property
    /// </summary>
    public string PropertyValue { get; set; } = string.Empty;

    /// <summary>
    /// Gets the value which indicates whether the property should be a private field
    /// </summary>
    public bool IsPrivateField => !string.IsNullOrWhiteSpace(PropertyName) && PropertyName.StartsWith('_');

    /// <summary>
    /// Gets the value which indicates whether the property aka file entry is "valid"
    /// </summary>
    public bool IsValid => !string.IsNullOrEmpty(PropertyName) && !string.IsNullOrEmpty(PropertyValue) && !PropertyName.StartsWithNumber();

    /// <summary>
    /// Gets or sets the info
    /// </summary>
    /// <remarks>
    /// <b>Note</b>: This property is only need for invalid entries
    /// </remarks>
    public string Info { get; set; } = string.Empty;
}