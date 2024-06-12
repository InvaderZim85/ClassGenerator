namespace ClassGenerator.DataObjects;

/// <summary>
/// Provides the result of the class generator
/// </summary>
internal sealed class GeneratorResult
{
    /// <summary>
    /// Gets or sets the class code
    /// </summary>
    public string ClassCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the error message
    /// </summary>
    public string ErrorMessage { get; set; } = string.Empty;
}