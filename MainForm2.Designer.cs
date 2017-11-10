namespace voice_recognition.cs
{
    partial class MainForm2
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
            this.Speak = new System.Windows.Forms.Button();
            this.Sentence = new System.Windows.Forms.RichTextBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Module = new System.Windows.Forms.ToolStripMenuItem();
            this.Language = new System.Windows.Forms.ToolStripMenuItem();
            this.Volume = new System.Windows.Forms.ToolStripMenuItem();
            this.Pitch = new System.Windows.Forms.ToolStripMenuItem();
            this.SpeechRate = new System.Windows.Forms.ToolStripMenuItem();
            this.SetVolume = new System.Windows.Forms.NumericUpDown();
            this.SetPitch = new System.Windows.Forms.NumericUpDown();
            this.SetSpeechRate = new System.Windows.Forms.NumericUpDown();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetSpeechRate)).BeginInit();
            this.SuspendLayout();
            // 
            // Speak
            // 
            this.Speak.Location = new System.Drawing.Point(511, 64);
            this.Speak.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Speak.Name = "Speak";
            this.Speak.Size = new System.Drawing.Size(100, 28);
            this.Speak.TabIndex = 2;
            this.Speak.Text = "Speak";
            this.Speak.UseVisualStyleBackColor = true;
            this.Speak.Click += new System.EventHandler(this.Speak_Click);
            // 
            // Sentence
            // 
            this.Sentence.Location = new System.Drawing.Point(11, 64);
            this.Sentence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Sentence.Multiline = false;
            this.Sentence.Name = "Sentence";
            this.Sentence.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Sentence.Size = new System.Drawing.Size(491, 27);
            this.Sentence.TabIndex = 3;
            this.Sentence.Text = "";
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Module,
            this.Language,
            this.Volume,
            this.Pitch,
            this.SpeechRate});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MainMenu.Size = new System.Drawing.Size(627, 28);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "MainMenu";
            // 
            // Module
            // 
            this.Module.Name = "Module";
            this.Module.Size = new System.Drawing.Size(72, 24);
            this.Module.Text = "Module";
            // 
            // Language
            // 
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(86, 24);
            this.Language.Text = "Language";
            // 
            // Volume
            // 
            this.Volume.Name = "Volume";
            this.Volume.Size = new System.Drawing.Size(72, 24);
            this.Volume.Text = "Volume";
            // 
            // Pitch
            // 
            this.Pitch.Name = "Pitch";
            this.Pitch.Size = new System.Drawing.Size(53, 24);
            this.Pitch.Text = "Pitch";
            // 
            // SpeechRate
            // 
            this.SpeechRate.Name = "SpeechRate";
            this.SpeechRate.Size = new System.Drawing.Size(103, 24);
            this.SpeechRate.Text = "Speech Rate";
            // 
            // SetVolume
            // 
            this.SetVolume.Location = new System.Drawing.Point(197, 31);
            this.SetVolume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SetVolume.Name = "SetVolume";
            this.SetVolume.Size = new System.Drawing.Size(53, 22);
            this.SetVolume.TabIndex = 5;
            this.SetVolume.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.SetVolume.ValueChanged += new System.EventHandler(this.SetVolume_ValueChanged);
            // 
            // SetPitch
            // 
            this.SetPitch.Location = new System.Drawing.Point(269, 31);
            this.SetPitch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SetPitch.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.SetPitch.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SetPitch.Name = "SetPitch";
            this.SetPitch.Size = new System.Drawing.Size(53, 22);
            this.SetPitch.TabIndex = 6;
            this.SetPitch.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SetPitch.ValueChanged += new System.EventHandler(this.SetPitch_ValueChanged);
            // 
            // SetSpeechRate
            // 
            this.SetSpeechRate.Location = new System.Drawing.Point(349, 31);
            this.SetSpeechRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SetSpeechRate.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.SetSpeechRate.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SetSpeechRate.Name = "SetSpeechRate";
            this.SetSpeechRate.Size = new System.Drawing.Size(53, 22);
            this.SetSpeechRate.TabIndex = 7;
            this.SetSpeechRate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SetSpeechRate.ValueChanged += new System.EventHandler(this.SetSpeechRate_ValueChanged);
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 124);
            this.Controls.Add(this.SetSpeechRate);
            this.Controls.Add(this.SetPitch);
            this.Controls.Add(this.SetVolume);
            this.Controls.Add(this.Sentence);
            this.Controls.Add(this.Speak);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm2";
            this.Text = " Voice Synthesis";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetSpeechRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Speak;
        private System.Windows.Forms.RichTextBox Sentence;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Module;
        private System.Windows.Forms.ToolStripMenuItem Language;
        private System.Windows.Forms.NumericUpDown SetVolume;
        private System.Windows.Forms.ToolStripMenuItem Volume;
        private System.Windows.Forms.ToolStripMenuItem Pitch;
        private System.Windows.Forms.NumericUpDown SetPitch;
        private System.Windows.Forms.ToolStripMenuItem SpeechRate;
        private System.Windows.Forms.NumericUpDown SetSpeechRate;
    }
}