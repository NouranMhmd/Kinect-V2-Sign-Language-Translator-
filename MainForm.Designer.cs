namespace voice_recognition.cs
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.moduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dictationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setGrammarFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVocabularyFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsoleMode = new System.Windows.Forms.GroupBox();
            this.Console2 = new System.Windows.Forms.TreeView();
            this.Status2 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.GrammarFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.VocabFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainMenu.SuspendLayout();
            this.ConsoleMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moduleToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.languageToolStripMenuItem1,
            this.modeToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MainMenu.Size = new System.Drawing.Size(643, 28);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            //this.MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
            // 
            // moduleToolStripMenuItem
            // 
            this.moduleToolStripMenuItem.Name = "moduleToolStripMenuItem";
            this.moduleToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.moduleToolStripMenuItem.Text = "Source";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.languageToolStripMenuItem.Text = "Module";
            // 
            // languageToolStripMenuItem1
            // 
            this.languageToolStripMenuItem1.Name = "languageToolStripMenuItem1";
            this.languageToolStripMenuItem1.Size = new System.Drawing.Size(86, 24);
            this.languageToolStripMenuItem1.Text = "Language";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandControlToolStripMenuItem,
            this.dictationToolStripMenuItem,
            this.toolStripSeparator1,
            this.setGrammarFromFileToolStripMenuItem,
            this.addVocabularyFromFileToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // commandControlToolStripMenuItem
            // 
            this.commandControlToolStripMenuItem.Name = "commandControlToolStripMenuItem";
            this.commandControlToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.commandControlToolStripMenuItem.Text = "Command Control";
            this.commandControlToolStripMenuItem.Click += new System.EventHandler(this.commandControlToolStripMenuItem_Click);
            // 
            // dictationToolStripMenuItem
            // 
            this.dictationToolStripMenuItem.Name = "dictationToolStripMenuItem";
            this.dictationToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.dictationToolStripMenuItem.Text = "Dictation";
            this.dictationToolStripMenuItem.Click += new System.EventHandler(this.dictationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
            // 
            // setGrammarFromFileToolStripMenuItem
            // 
            this.setGrammarFromFileToolStripMenuItem.Enabled = false;
            this.setGrammarFromFileToolStripMenuItem.Name = "setGrammarFromFileToolStripMenuItem";
            this.setGrammarFromFileToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.setGrammarFromFileToolStripMenuItem.Text = "Set Grammar from File";
            this.setGrammarFromFileToolStripMenuItem.Click += new System.EventHandler(this.setGrammarFromFileToolStripMenuItem_Click);
            // 
            // addVocabularyFromFileToolStripMenuItem
            // 
            this.addVocabularyFromFileToolStripMenuItem.Enabled = false;
            this.addVocabularyFromFileToolStripMenuItem.Name = "addVocabularyFromFileToolStripMenuItem";
            this.addVocabularyFromFileToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.addVocabularyFromFileToolStripMenuItem.Text = "Add Vocabulary from File";
            this.addVocabularyFromFileToolStripMenuItem.Click += new System.EventHandler(this.addVocabularyFromFileToolStripMenuItem_Click);
            // 
            // ConsoleMode
            // 
            this.ConsoleMode.Controls.Add(this.Console2);
            this.ConsoleMode.Location = new System.Drawing.Point(3, 31);
            this.ConsoleMode.Margin = new System.Windows.Forms.Padding(4);
            this.ConsoleMode.Name = "ConsoleMode";
            this.ConsoleMode.Padding = new System.Windows.Forms.Padding(4);
            this.ConsoleMode.Size = new System.Drawing.Size(627, 266);
            this.ConsoleMode.TabIndex = 1;
            this.ConsoleMode.TabStop = false;
            this.ConsoleMode.Text = "Dictation:";
            // 
            // Console2
            // 
            this.Console2.FullRowSelect = true;
            this.Console2.Indent = 5;
            this.Console2.LabelEdit = true;
            this.Console2.Location = new System.Drawing.Point(8, 25);
            this.Console2.Margin = new System.Windows.Forms.Padding(4);
            this.Console2.Name = "Console2";
            this.Console2.ShowLines = false;
            this.Console2.Size = new System.Drawing.Size(609, 233);
            this.Console2.TabIndex = 0;
            // 
            // Status2
            // 
            this.Status2.Indent = 5;
            this.Status2.Location = new System.Drawing.Point(12, 330);
            this.Status2.Margin = new System.Windows.Forms.Padding(4);
            this.Status2.Name = "Status2";
            this.Status2.ShowLines = false;
            this.Status2.Size = new System.Drawing.Size(608, 139);
            this.Status2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 306);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(625, 171);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status:";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(61, 485);
            this.Start.Margin = new System.Windows.Forms.Padding(4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 28);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(437, 485);
            this.Stop.Margin = new System.Windows.Forms.Padding(4);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(100, 28);
            this.Stop.TabIndex = 5;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // GrammarFileDialog
            // 
            this.GrammarFileDialog.DefaultExt = "jsgf";
            this.GrammarFileDialog.FileName = "openFileDialog1";
            // 
            // VocabFileDialog
            // 
            this.VocabFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 524);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Status2);
            this.Controls.Add(this.ConsoleMode);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Voice Recognition";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ConsoleMode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem moduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dictationToolStripMenuItem;
        private System.Windows.Forms.GroupBox ConsoleMode;
        private System.Windows.Forms.TreeView Console2;
        private System.Windows.Forms.TreeView Status2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.ToolStripMenuItem setGrammarFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVocabularyFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog GrammarFileDialog;
        private System.Windows.Forms.OpenFileDialog VocabFileDialog;
    }
}