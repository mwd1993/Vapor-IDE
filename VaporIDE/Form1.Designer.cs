
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace VaporIDE
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.codeView = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.executeButton = new System.Windows.Forms.Button();
            this.BuildButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.releaseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.methodList = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.debugTextLabel = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.locateParserButton = new System.Windows.Forms.Button();
            this.documentationButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.usingMethodsList = new System.Windows.Forms.ListBox();
            this.standardLibraryButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locateParserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadStandardLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewReleasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vaporSyntaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeView
            // 
            this.codeView.AcceptsTab = true;
            this.codeView.BackColor = System.Drawing.SystemColors.GrayText;
            this.codeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeView.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.codeView.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.codeView.Location = new System.Drawing.Point(8, 8);
            this.codeView.Name = "codeView";
            this.codeView.Size = new System.Drawing.Size(897, 562);
            this.codeView.TabIndex = 0;
            this.codeView.Text = "";
            this.codeView.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.codeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codeView_KeyDown);
            this.codeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.codeView_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.codeView);
            this.panel1.Controls.Add(this.executeButton);
            this.panel1.Controls.Add(this.BuildButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.importButton);
            this.panel1.Controls.Add(this.clearButton);
            this.panel1.Controls.Add(this.releaseButton);
            this.panel1.Location = new System.Drawing.Point(30, 86);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(913, 578);
            this.panel1.TabIndex = 1;
            // 
            // executeButton
            // 
            this.executeButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.executeButton.FlatAppearance.BorderSize = 0;
            this.executeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.executeButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.executeButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.executeButton.Location = new System.Drawing.Point(0, 535);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(144, 43);
            this.executeButton.TabIndex = 3;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = false;
            this.executeButton.Visible = false;
            this.executeButton.Click += new System.EventHandler(this.executeButtonOnClick);
            this.executeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // BuildButton
            // 
            this.BuildButton.BackColor = System.Drawing.Color.OrangeRed;
            this.BuildButton.FlatAppearance.BorderSize = 0;
            this.BuildButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuildButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BuildButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.BuildButton.Location = new System.Drawing.Point(0, 467);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(144, 43);
            this.BuildButton.TabIndex = 17;
            this.BuildButton.Text = "Build";
            this.BuildButton.UseVisualStyleBackColor = false;
            this.BuildButton.Visible = false;
            this.BuildButton.Click += new System.EventHandler(this.buildButton_click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Peru;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.saveButton.Location = new System.Drawing.Point(195, 535);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(144, 43);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButtonOnClick);
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.Color.SteelBlue;
            this.importButton.FlatAppearance.BorderSize = 0;
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.importButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.importButton.Location = new System.Drawing.Point(391, 535);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(144, 43);
            this.importButton.TabIndex = 6;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Visible = false;
            this.importButton.Click += new System.EventHandler(this.importButtonOnClick);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Brown;
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clearButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.clearButton.Location = new System.Drawing.Point(579, 535);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(144, 43);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Visible = false;
            this.clearButton.Click += new System.EventHandler(this.clearButtonOnClick);
            // 
            // releaseButton
            // 
            this.releaseButton.BackColor = System.Drawing.Color.MediumPurple;
            this.releaseButton.FlatAppearance.BorderSize = 0;
            this.releaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.releaseButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.releaseButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.releaseButton.Location = new System.Drawing.Point(769, 535);
            this.releaseButton.Name = "releaseButton";
            this.releaseButton.Size = new System.Drawing.Size(144, 43);
            this.releaseButton.TabIndex = 4;
            this.releaseButton.Text = "Releases";
            this.releaseButton.UseVisualStyleBackColor = false;
            this.releaseButton.Visible = false;
            this.releaseButton.Click += new System.EventHandler(this.releasesButtonOnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(448, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vapor IDE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel2.Controls.Add(this.methodList);
            this.panel2.Location = new System.Drawing.Point(970, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 237);
            this.panel2.TabIndex = 7;
            // 
            // methodList
            // 
            this.methodList.BackColor = System.Drawing.SystemColors.GrayText;
            this.methodList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.methodList.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.methodList.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.methodList.FormattingEnabled = true;
            this.methodList.HorizontalScrollbar = true;
            this.methodList.ItemHeight = 11;
            this.methodList.Location = new System.Drawing.Point(16, 9);
            this.methodList.Name = "methodList";
            this.methodList.Size = new System.Drawing.Size(213, 220);
            this.methodList.TabIndex = 0;
            this.methodList.SelectedIndexChanged += new System.EventHandler(this.methodList_SelectedIndexChanged);
            this.methodList.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            this.methodList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.Location = new System.Drawing.Point(146, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 29);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "VaporFile.vap";
            // 
            // debugTextLabel
            // 
            this.debugTextLabel.AutoSize = true;
            this.debugTextLabel.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.debugTextLabel.Location = new System.Drawing.Point(31, 684);
            this.debugTextLabel.Name = "debugTextLabel";
            this.debugTextLabel.Size = new System.Drawing.Size(0, 24);
            this.debugTextLabel.TabIndex = 9;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.IndianRed;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button5.Location = new System.Drawing.Point(1226, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(16, 15);
            this.button5.TabIndex = 10;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(1046, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Methods";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // locateParserButton
            // 
            this.locateParserButton.BackColor = System.Drawing.Color.LightBlue;
            this.locateParserButton.FlatAppearance.BorderSize = 0;
            this.locateParserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.locateParserButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.locateParserButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.locateParserButton.Location = new System.Drawing.Point(22, 187);
            this.locateParserButton.Name = "locateParserButton";
            this.locateParserButton.Size = new System.Drawing.Size(197, 43);
            this.locateParserButton.TabIndex = 13;
            this.locateParserButton.Text = "Locate Parser";
            this.locateParserButton.UseVisualStyleBackColor = false;
            this.locateParserButton.Visible = false;
            this.locateParserButton.Click += new System.EventHandler(this.locateParserButtonOnClick);
            // 
            // documentationButton
            // 
            this.documentationButton.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.documentationButton.FlatAppearance.BorderSize = 0;
            this.documentationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.documentationButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.documentationButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.documentationButton.Location = new System.Drawing.Point(992, 343);
            this.documentationButton.Name = "documentationButton";
            this.documentationButton.Size = new System.Drawing.Size(197, 43);
            this.documentationButton.TabIndex = 14;
            this.documentationButton.Text = "Documentation";
            this.documentationButton.UseVisualStyleBackColor = false;
            this.documentationButton.Click += new System.EventHandler(this.documentationButtonOnClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(30, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "File Name :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(1015, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Using Methods";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel3.Controls.Add(this.usingMethodsList);
            this.panel3.Controls.Add(this.standardLibraryButton);
            this.panel3.Controls.Add(this.locateParserButton);
            this.panel3.Location = new System.Drawing.Point(970, 434);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(247, 230);
            this.panel3.TabIndex = 8;
            // 
            // usingMethodsList
            // 
            this.usingMethodsList.BackColor = System.Drawing.SystemColors.GrayText;
            this.usingMethodsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usingMethodsList.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usingMethodsList.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.usingMethodsList.FormattingEnabled = true;
            this.usingMethodsList.HorizontalScrollbar = true;
            this.usingMethodsList.ItemHeight = 11;
            this.usingMethodsList.Location = new System.Drawing.Point(16, 9);
            this.usingMethodsList.Name = "usingMethodsList";
            this.usingMethodsList.Size = new System.Drawing.Size(213, 209);
            this.usingMethodsList.TabIndex = 0;
            this.usingMethodsList.SelectedValueChanged += new System.EventHandler(this.usingMethodsList_SelectedValueChanged);
            // 
            // standardLibraryButton
            // 
            this.standardLibraryButton.BackColor = System.Drawing.Color.OliveDrab;
            this.standardLibraryButton.FlatAppearance.BorderSize = 0;
            this.standardLibraryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.standardLibraryButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.standardLibraryButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.standardLibraryButton.Location = new System.Drawing.Point(22, 138);
            this.standardLibraryButton.Name = "standardLibraryButton";
            this.standardLibraryButton.Size = new System.Drawing.Size(197, 43);
            this.standardLibraryButton.TabIndex = 18;
            this.standardLibraryButton.Text = "Standard Lib.";
            this.standardLibraryButton.UseVisualStyleBackColor = false;
            this.standardLibraryButton.Visible = false;
            this.standardLibraryButton.Click += new System.EventHandler(this.standardLibraryButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1250, 31);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.executeToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.importToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(133, 24);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.buildToolStripMenuItem.Text = "Build";
            this.buildToolStripMenuItem.Click += new System.EventHandler(this.buildToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.importToolStripMenuItem.Text = "Open";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locateParserToolStripMenuItem,
            this.downloadStandardLibraryToolStripMenuItem,
            this.viewReleasesToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // locateParserToolStripMenuItem
            // 
            this.locateParserToolStripMenuItem.Name = "locateParserToolStripMenuItem";
            this.locateParserToolStripMenuItem.Size = new System.Drawing.Size(273, 24);
            this.locateParserToolStripMenuItem.Text = "Locate Parser";
            this.locateParserToolStripMenuItem.Click += new System.EventHandler(this.locateParserToolStripMenuItem_Click);
            // 
            // downloadStandardLibraryToolStripMenuItem
            // 
            this.downloadStandardLibraryToolStripMenuItem.Name = "downloadStandardLibraryToolStripMenuItem";
            this.downloadStandardLibraryToolStripMenuItem.Size = new System.Drawing.Size(273, 24);
            this.downloadStandardLibraryToolStripMenuItem.Text = "Download Standard Library";
            this.downloadStandardLibraryToolStripMenuItem.Click += new System.EventHandler(this.downloadStandardLibraryToolStripMenuItem_Click);
            // 
            // viewReleasesToolStripMenuItem
            // 
            this.viewReleasesToolStripMenuItem.Name = "viewReleasesToolStripMenuItem";
            this.viewReleasesToolStripMenuItem.Size = new System.Drawing.Size(273, 24);
            this.viewReleasesToolStripMenuItem.Text = "View Releases";
            this.viewReleasesToolStripMenuItem.Click += new System.EventHandler(this.viewReleasesToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vaporSyntaxToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(56, 23);
            this.saveToolStripMenuItem.Text = "Help";
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(73, 23);
            this.donateToolStripMenuItem.Text = "Donate";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // vaporSyntaxToolStripMenuItem
            // 
            this.vaporSyntaxToolStripMenuItem.Name = "vaporSyntaxToolStripMenuItem";
            this.vaporSyntaxToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.vaporSyntaxToolStripMenuItem.Text = "Vapor Syntax";
            this.vaporSyntaxToolStripMenuItem.Click += new System.EventHandler(this.vaporSyntaxToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1250, 728);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.documentationButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.debugTextLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Opacity = 0.96D;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeView;
        private Panel panel1;
        private Label label1;
        private Button executeButton;
        private Button releaseButton;
        private Button saveButton;
        private Button importButton;
        private Panel panel2;
        private ListBox methodList;
        private TextBox textBox1;
        private Label debugTextLabel;
        private Button button5;
        private Label label3;
        private Button clearButton;
        private Button locateParserButton;
        private Button documentationButton;
        private Label label5;
        private Label label2;
        private Panel panel3;
        private ListBox usingMethodsList;
        private Button BuildButton;
        private Button standardLibraryButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem donateToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem setupToolStripMenuItem;
        private ToolStripMenuItem locateParserToolStripMenuItem;
        private ToolStripMenuItem downloadStandardLibraryToolStripMenuItem;
        private ToolStripMenuItem viewReleasesToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripMenuItem executeToolStripMenuItem;
        private ToolStripMenuItem buildToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem vaporSyntaxToolStripMenuItem;
    }
}

