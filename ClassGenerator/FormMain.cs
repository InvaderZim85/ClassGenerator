using ClassGenerator.Business;
using ClassGenerator.Common;
using ClassGenerator.DataObjects;
using ScintillaNET;

namespace ClassGenerator;

public partial class FormMain : Form
{
    /// <summary>
    /// Contains the max. line number char length
    /// </summary>
    private int _maxLineNumberCharLength;

    /// <summary>
    /// Creates a new instance of the <see cref="FormMain"/>
    /// </summary>
    public FormMain()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Creates the class according to the specified instructions
    /// </summary>
    private async void CreateClass()
    {
        // Validate the values
        if (!InputValid())
            return;

        tabControl.Enabled = false;
        Cursor = Cursors.WaitCursor;

        try
        {
            var options = new GeneratorOptions
            {
                SourceFile = textBoxSource.Text,
                ClassName = textBoxClassName.Text,
                NameSpace = textBoxNamespace.Text,
                Modifier = comboBoxModifier.Text,
                FileScopedNamespace = checkBoxFileScopedNamespace.Checked,
                AddSummary = checkBoxAddSummary.Checked,
                SealedClass = checkBoxSealed.Checked
            };

            var result = await Generator.GenerateClassAsync(options);

            scintillaClass.Text = result.ClassCode;
            textBoxError.Text = result.ErrorMessage;

            if (string.IsNullOrEmpty(result.ErrorMessage))
                return;

            MessageBox.Show("One or more errors occurred when generating the class.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            // Show the error tab
            tabControl.SelectedTab = tabPageError;
        }
        catch
        {
            MessageBox.Show("An error has occurred while creating the class code.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            tabControl.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    /// <summary>
    /// Validates the input
    /// </summary>
    /// <returns><see langword="true"/> the input is valid, otherwise <see langword="false"/></returns>
    private bool InputValid()
    {
        const string mandatoryFieldMessage = "Mandatory field. Must not be empty.";
        const string classNameFailure = "The name must not begin with a number.";

        var isValid = true;
        errorProvider.Clear();

        if (string.IsNullOrWhiteSpace(textBoxSource.Text))
        {
            SetError(textBoxSource, mandatoryFieldMessage);
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(textBoxClassName.Text))
        {
            SetError(textBoxClassName, mandatoryFieldMessage);
            isValid = false;
        }
        else if (textBoxClassName.Text.StartsWithNumber())
        {
            SetError(textBoxClassName, classNameFailure);
            isValid = false;
        }

        if (!string.IsNullOrWhiteSpace(textBoxNamespace.Text) && textBoxNamespace.Text.StartsWithNumber())
        {
            SetError(textBoxNamespace, classNameFailure);
            isValid = false;
        }

        return isValid;

        void SetError(Control control, string message)
        {
            errorProvider.SetError(control, message);
            errorProvider.SetIconPadding(control, -20);
        }
    }

    /// <summary>
    /// Updates the line numbers of scintilla
    /// </summary>
    /// <param name="startingAtLine">The starting line</param>
    private void UpdateLineNumbers(int startingAtLine)
    {
        // Starting at the specified line index, update each
        // subsequent line margin text with a hex line number.
        for (var i = startingAtLine; i < scintillaClass.Lines.Count; i++)
        {
            scintillaClass.Lines[i].MarginStyle = Style.LineNumber;
            scintillaClass.Lines[i].MarginText = "0x" + i.ToString("X2");
        }
    }

    /// <summary>
    /// Occurs when the user hits the browse button (next to the source text box)
    /// </summary>
    /// <param name="sender">The <see cref="buttonBrowseSource"/></param>
    /// <param name="e">The event arguments</param>
    private void ButtonBrowseSource_Click(object sender, EventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Text file (*.txt)|*.txt"
        };

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        textBoxSource.Text = dialog.FileName;
    }

    /// <summary>
    /// Occurs when the user hits the create button (over the tab control)
    /// </summary>
    /// <param name="sender">The <see cref="buttonCreate"/></param>
    /// <param name="e">The event arguments</param>
    private void ButtonCreate_Click(object sender, EventArgs e)
    {
        CreateClass();
    }

    /// <summary>
    /// Occurs when the user hits the clear button (over the tab control)
    /// </summary>
    /// <param name="sender">The <see cref="buttonClear"/></param>
    /// <param name="e">The event arguments</param>
    private void ButtonClear_Click(object sender, EventArgs e)
    {
        // Clears every input
        foreach (var textBox in tableLayoutPanel.Controls.OfType<TextBox>())
        {
            textBox.Clear();
        }

        scintillaClass.Text = string.Empty;
        textBoxError.Clear();
    }

    /// <summary>
    /// Occurs when the user hits the save button (under the tab control)
    /// </summary>
    /// <param name="sender">The <see cref="buttonSave"/></param>
    /// <param name="e">The event arguments</param>
    private void ButtonSave_Click(object sender, EventArgs e)
    {
        var dialog = new SaveFileDialog
        {
            Filter = "C# file (*.cs)|*.cs"
        };

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        File.WriteAllText(dialog.FileName, scintillaClass.Text);
    }

    /// <summary>
    /// Occurs when the form was loaded
    /// </summary>
    /// <param name="sender">The <see cref="FormMain"/></param>
    /// <param name="e">The event arguments</param>
    private void FormMain_Load(object sender, EventArgs e)
    {
        // Configuring the default style with properties
        // we have common to every lexer style saves time.
        scintillaClass.StyleResetDefault();
        scintillaClass.Styles[Style.Default].Font = "Consolas";
        scintillaClass.Styles[Style.Default].Size = 10;
        scintillaClass.StyleClearAll();

        // Configure the CPP (C#) lexer styles
        scintillaClass.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
        scintillaClass.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
        scintillaClass.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
        scintillaClass.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(0, 150, 0); // Gray
        scintillaClass.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
        scintillaClass.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
        scintillaClass.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
        scintillaClass.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
        scintillaClass.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
        scintillaClass.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
        scintillaClass.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
        scintillaClass.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
        scintillaClass.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
        scintillaClass.LexerName = "cpp";

        // Set the keywords
        scintillaClass.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
        scintillaClass.SetKeywords(1, "DateTime bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");

        comboBoxModifier.SelectedIndex = 0;
    }

    /// <summary>
    /// Occurs when a new line was added
    /// </summary>
    /// <param name="sender">The <see cref="scintillaClass"/></param>
    /// <param name="e">The event arguments</param>
    private void Scintilla_Insert(object sender, ModificationEventArgs e)
    {
        // Only update line numbers if the number of lines changed
        if (e.LinesAdded != 0)
            UpdateLineNumbers(scintillaClass.LineFromPosition(e.Position));
    }

    /// <summary>
    /// Occurs when a line was removed
    /// </summary>
    /// <param name="sender">The <see cref="scintillaClass"/></param>
    /// <param name="e">The event arguments</param>
    private void Scintilla_Delete(object sender, ModificationEventArgs e)
    {
        // Only update line numbers if the number of lines changed
        if (e.LinesAdded != 0)
            UpdateLineNumbers(scintillaClass.LineFromPosition(e.Position));
    }

    /// <summary>
    /// Occurs when the text of the scintilla control was changed
    /// </summary>
    /// <param name="sender">The <see cref="scintillaClass"/></param>
    /// <param name="e">The event arguments</param>
    private void Scintilla_TextChanged(object sender, EventArgs e)
    {
        // Did the number of characters in the line number display change?
        // i.e. nnn VS nn, or nnnn VS nn, etc...
        var maxLineNumberCharLength = scintillaClass.Lines.Count.ToString().Length;
        if (maxLineNumberCharLength == _maxLineNumberCharLength)
            return;

        // Calculate the width required to display the last line number
        // and include some padding for good measure.
        const int padding = 2;
        scintillaClass.Margins[0].Width =
            scintillaClass.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
        _maxLineNumberCharLength = maxLineNumberCharLength;
    }

    /// <summary>
    /// Occurs when the user hits the copy button
    /// </summary>
    /// <param name="sender">The <see cref="buttonCopy"/></param>
    /// <param name="e">The event arguments</param>
    private void ButtonCopy_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(scintillaClass.Text))
            return;

        Clipboard.SetText(scintillaClass.Text, TextDataFormat.Text);
    }
}