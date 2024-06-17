using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGenerator.DataObjects;

/// <summary>
/// Provides the generator options
/// </summary>
internal sealed class GeneratorOptions
{
    /// <summary>
    /// Gets or sets the source file path
    /// </summary>
    public required string SourceFile { get; set; }

    /// <summary>
    /// Gets or sets the name of the target class
    /// </summary>
    public required string ClassName { get; set; }

    /// <summary>
    /// Gets or sets the name space
    /// </summary>
    public string NameSpace { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the class modifier
    /// </summary>
    public required string Modifier { get; set; }

    /// <summary>
    /// Gets or sets the value which indicates whether a file scoped namespace should be created
    /// </summary>
    public required bool FileScopedNamespace { get; set; }

    /// <summary>
    /// Gets or sets the value which indicates whether a summary should be added
    /// </summary>
    public required bool AddSummary { get; set; }

    /// <summary>
    /// Gets or sets the value which indicates whether the class should be marked as sealed
    /// </summary>
    public required bool SealedClass { get; set; }
}