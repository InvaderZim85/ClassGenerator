namespace ClassGenerator
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            tableLayoutPanel = new TableLayoutPanel();
            labelSourceFile = new Label();
            labelNamespace = new Label();
            tabControl = new TabControl();
            tabPageClass = new TabPage();
            scintillaClass = new ScintillaNET.Scintilla();
            tabPageError = new TabPage();
            textBoxError = new TextBox();
            buttonBrowseSource = new Button();
            textBoxSource = new TextBox();
            textBoxNamespace = new TextBox();
            panelButtons = new Panel();
            buttonCreate = new Button();
            panelBottom = new Panel();
            buttonCopy = new Button();
            labelInfo = new Label();
            buttonSave = new Button();
            buttonClear = new Button();
            textBoxClassName = new TextBox();
            labelClassName = new Label();
            labelOptions = new Label();
            panelOptions = new Panel();
            checkBoxAddSummary = new CheckBox();
            checkBoxFileScopedNamespace = new CheckBox();
            errorProvider = new ErrorProvider(components);
            labelModifier = new Label();
            comboBoxModifier = new ComboBox();
            checkBoxSealed = new CheckBox();
            tableLayoutPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageClass.SuspendLayout();
            tabPageError.SuspendLayout();
            panelButtons.SuspendLayout();
            panelBottom.SuspendLayout();
            panelOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.Controls.Add(labelSourceFile, 0, 0);
            tableLayoutPanel.Controls.Add(labelNamespace, 0, 2);
            tableLayoutPanel.Controls.Add(tabControl, 0, 6);
            tableLayoutPanel.Controls.Add(buttonBrowseSource, 2, 0);
            tableLayoutPanel.Controls.Add(textBoxSource, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxNamespace, 1, 2);
            tableLayoutPanel.Controls.Add(panelButtons, 0, 5);
            tableLayoutPanel.Controls.Add(panelBottom, 0, 7);
            tableLayoutPanel.Controls.Add(textBoxClassName, 1, 1);
            tableLayoutPanel.Controls.Add(labelClassName, 0, 1);
            tableLayoutPanel.Controls.Add(labelOptions, 0, 4);
            tableLayoutPanel.Controls.Add(panelOptions, 1, 4);
            tableLayoutPanel.Controls.Add(labelModifier, 0, 3);
            tableLayoutPanel.Controls.Add(comboBoxModifier, 1, 3);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 8;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Size = new Size(981, 665);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelSourceFile
            // 
            labelSourceFile.AutoSize = true;
            labelSourceFile.Dock = DockStyle.Fill;
            labelSourceFile.Location = new Point(3, 0);
            labelSourceFile.Name = "labelSourceFile";
            labelSourceFile.Size = new Size(72, 29);
            labelSourceFile.TabIndex = 0;
            labelSourceFile.Text = "Source file:";
            labelSourceFile.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelNamespace
            // 
            labelNamespace.AutoSize = true;
            labelNamespace.Dock = DockStyle.Fill;
            labelNamespace.Location = new Point(3, 58);
            labelNamespace.Name = "labelNamespace";
            labelNamespace.Size = new Size(72, 29);
            labelNamespace.TabIndex = 1;
            labelNamespace.Text = "Namespace:";
            labelNamespace.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabControl
            // 
            tableLayoutPanel.SetColumnSpan(tabControl, 3);
            tabControl.Controls.Add(tabPageClass);
            tabControl.Controls.Add(tabPageError);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(3, 177);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(975, 456);
            tabControl.TabIndex = 3;
            // 
            // tabPageClass
            // 
            tabPageClass.Controls.Add(scintillaClass);
            tabPageClass.Location = new Point(4, 24);
            tabPageClass.Name = "tabPageClass";
            tabPageClass.Padding = new Padding(3);
            tabPageClass.Size = new Size(967, 428);
            tabPageClass.TabIndex = 0;
            tabPageClass.Text = "Class";
            tabPageClass.UseVisualStyleBackColor = true;
            // 
            // scintillaClass
            // 
            scintillaClass.AutocompleteListSelectedBackColor = Color.FromArgb(0, 120, 215);
            scintillaClass.Dock = DockStyle.Fill;
            scintillaClass.LexerName = "";
            scintillaClass.Location = new Point(3, 3);
            scintillaClass.Name = "scintillaClass";
            scintillaClass.ScrollWidth = 49;
            scintillaClass.Size = new Size(961, 422);
            scintillaClass.TabIndex = 0;
            scintillaClass.Delete += Scintilla_Delete;
            scintillaClass.Insert += Scintilla_Insert;
            scintillaClass.TextChanged += Scintilla_TextChanged;
            // 
            // tabPageError
            // 
            tabPageError.Controls.Add(textBoxError);
            tabPageError.Location = new Point(4, 24);
            tabPageError.Name = "tabPageError";
            tabPageError.Padding = new Padding(3);
            tabPageError.Size = new Size(967, 457);
            tabPageError.TabIndex = 1;
            tabPageError.Text = "Error";
            tabPageError.UseVisualStyleBackColor = true;
            // 
            // textBoxError
            // 
            textBoxError.Dock = DockStyle.Fill;
            textBoxError.Location = new Point(3, 3);
            textBoxError.Multiline = true;
            textBoxError.Name = "textBoxError";
            textBoxError.ReadOnly = true;
            textBoxError.Size = new Size(961, 451);
            textBoxError.TabIndex = 0;
            // 
            // buttonBrowseSource
            // 
            buttonBrowseSource.Dock = DockStyle.Fill;
            buttonBrowseSource.Location = new Point(944, 3);
            buttonBrowseSource.Name = "buttonBrowseSource";
            buttonBrowseSource.Size = new Size(34, 23);
            buttonBrowseSource.TabIndex = 4;
            buttonBrowseSource.Text = "...";
            buttonBrowseSource.UseVisualStyleBackColor = true;
            buttonBrowseSource.Click += ButtonBrowseSource_Click;
            // 
            // textBoxSource
            // 
            textBoxSource.Dock = DockStyle.Fill;
            textBoxSource.Location = new Point(81, 3);
            textBoxSource.Name = "textBoxSource";
            textBoxSource.Size = new Size(857, 23);
            textBoxSource.TabIndex = 5;
            // 
            // textBoxNamespace
            // 
            textBoxNamespace.Dock = DockStyle.Fill;
            textBoxNamespace.Location = new Point(81, 61);
            textBoxNamespace.Name = "textBoxNamespace";
            textBoxNamespace.Size = new Size(857, 23);
            textBoxNamespace.TabIndex = 6;
            // 
            // panelButtons
            // 
            panelButtons.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(panelButtons, 3);
            panelButtons.Controls.Add(buttonCreate);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(0, 145);
            panelButtons.Margin = new Padding(0);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(981, 29);
            panelButtons.TabIndex = 9;
            // 
            // buttonCreate
            // 
            buttonCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCreate.Location = new Point(903, 3);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(75, 23);
            buttonCreate.TabIndex = 1;
            buttonCreate.Text = "Create";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += ButtonCreate_Click;
            // 
            // panelBottom
            // 
            panelBottom.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(panelBottom, 3);
            panelBottom.Controls.Add(buttonCopy);
            panelBottom.Controls.Add(labelInfo);
            panelBottom.Controls.Add(buttonSave);
            panelBottom.Controls.Add(buttonClear);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.Location = new Point(0, 636);
            panelBottom.Margin = new Padding(0);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(981, 29);
            panelBottom.TabIndex = 10;
            // 
            // buttonCopy
            // 
            buttonCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCopy.Location = new Point(822, 3);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(75, 23);
            buttonCopy.TabIndex = 2;
            buttonCopy.Text = "Copy";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += ButtonCopy_Click;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(84, 7);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(525, 15);
            labelInfo.TabIndex = 1;
            labelInfo.Text = "Note: The class was generated automatically. It is therefore possible that the class is not functional.";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSave.Location = new Point(903, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(3, 3);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 0;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += ButtonClear_Click;
            // 
            // textBoxClassName
            // 
            textBoxClassName.Dock = DockStyle.Fill;
            textBoxClassName.Location = new Point(81, 32);
            textBoxClassName.Name = "textBoxClassName";
            textBoxClassName.Size = new Size(857, 23);
            textBoxClassName.TabIndex = 11;
            // 
            // labelClassName
            // 
            labelClassName.AutoSize = true;
            labelClassName.Dock = DockStyle.Fill;
            labelClassName.Location = new Point(3, 29);
            labelClassName.Name = "labelClassName";
            labelClassName.Size = new Size(72, 29);
            labelClassName.TabIndex = 12;
            labelClassName.Text = "Class name:";
            labelClassName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelOptions
            // 
            labelOptions.AutoSize = true;
            labelOptions.Dock = DockStyle.Fill;
            labelOptions.Location = new Point(3, 116);
            labelOptions.Name = "labelOptions";
            labelOptions.Size = new Size(72, 29);
            labelOptions.TabIndex = 14;
            labelOptions.Text = "Options:";
            labelOptions.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelOptions
            // 
            panelOptions.Controls.Add(checkBoxSealed);
            panelOptions.Controls.Add(checkBoxAddSummary);
            panelOptions.Controls.Add(checkBoxFileScopedNamespace);
            panelOptions.Dock = DockStyle.Fill;
            panelOptions.Location = new Point(78, 116);
            panelOptions.Margin = new Padding(0);
            panelOptions.Name = "panelOptions";
            panelOptions.Size = new Size(863, 29);
            panelOptions.TabIndex = 15;
            // 
            // checkBoxAddSummary
            // 
            checkBoxAddSummary.AutoSize = true;
            checkBoxAddSummary.Location = new Point(159, 8);
            checkBoxAddSummary.Name = "checkBoxAddSummary";
            checkBoxAddSummary.Size = new Size(101, 19);
            checkBoxAddSummary.TabIndex = 14;
            checkBoxAddSummary.Text = "Add summary";
            checkBoxAddSummary.UseVisualStyleBackColor = true;
            // 
            // checkBoxFileScopedNamespace
            // 
            checkBoxFileScopedNamespace.AutoSize = true;
            checkBoxFileScopedNamespace.Location = new Point(3, 8);
            checkBoxFileScopedNamespace.Name = "checkBoxFileScopedNamespace";
            checkBoxFileScopedNamespace.Size = new Size(150, 19);
            checkBoxFileScopedNamespace.TabIndex = 13;
            checkBoxFileScopedNamespace.Text = "File-scoped namespace";
            checkBoxFileScopedNamespace.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // labelModifier
            // 
            labelModifier.AutoSize = true;
            labelModifier.Dock = DockStyle.Fill;
            labelModifier.Location = new Point(3, 87);
            labelModifier.Name = "labelModifier";
            labelModifier.Size = new Size(72, 29);
            labelModifier.TabIndex = 16;
            labelModifier.Text = "Modifier:";
            labelModifier.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBoxModifier
            // 
            comboBoxModifier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxModifier.FormattingEnabled = true;
            comboBoxModifier.Items.AddRange(new object[] { "public", "internal", "protected", "protected internal" });
            comboBoxModifier.Location = new Point(81, 90);
            comboBoxModifier.Name = "comboBoxModifier";
            comboBoxModifier.Size = new Size(257, 23);
            comboBoxModifier.TabIndex = 17;
            // 
            // checkBoxSealed
            // 
            checkBoxSealed.AutoSize = true;
            checkBoxSealed.Location = new Point(266, 8);
            checkBoxSealed.Name = "checkBoxSealed";
            checkBoxSealed.Size = new Size(94, 19);
            checkBoxSealed.TabIndex = 15;
            checkBoxSealed.Text = "'Sealed' class";
            checkBoxSealed.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 665);
            Controls.Add(tableLayoutPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassGenerator";
            Load += FormMain_Load;
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageClass.ResumeLayout(false);
            tabPageError.ResumeLayout(false);
            tabPageError.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            panelOptions.ResumeLayout(false);
            panelOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label labelSourceFile;
        private Label labelNamespace;
        private TabControl tabControl;
        private TabPage tabPageClass;
        private TabPage tabPageError;
        private Button buttonBrowseSource;
        private TextBox textBoxSource;
        private TextBox textBoxNamespace;
        private ScintillaNET.Scintilla scintillaClass;
        private TextBox textBoxError;
        private Panel panelButtons;
        private Button buttonCreate;
        private Button buttonClear;
        private Panel panelBottom;
        private Button buttonSave;
        private TextBox textBoxClassName;
        private Label labelClassName;
        private ErrorProvider errorProvider;
        private CheckBox checkBoxFileScopedNamespace;
        private Label labelOptions;
        private Panel panelOptions;
        private CheckBox checkBoxAddSummary;
        private Label labelInfo;
        private Button buttonCopy;
        private Label labelModifier;
        private ComboBox comboBoxModifier;
        private CheckBox checkBoxSealed;
    }
}
