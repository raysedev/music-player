namespace music_player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.closeBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.musicBox = new System.Windows.Forms.ListBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.musicProgress = new System.Windows.Forms.TrackBar();
            this.musicLenght = new System.Windows.Forms.Label();
            this.replay = new System.Windows.Forms.CheckBox();
            this.volume = new System.Windows.Forms.TrackBar();
            this.settingsBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.musicProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.closeBtn.Location = new System.Drawing.Point(281, -6);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(31, 24);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.minimizeBtn.Location = new System.Drawing.Point(260, -6);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(31, 24);
            this.minimizeBtn.TabIndex = 1;
            this.minimizeBtn.Text = "–";
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            // 
            // musicBox
            // 
            this.musicBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.musicBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.musicBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.musicBox.FormattingEnabled = true;
            this.musicBox.HorizontalScrollbar = true;
            this.musicBox.ItemHeight = 16;
            this.musicBox.Items.AddRange(new object[] {
            "No music is found in the current folder"});
            this.musicBox.Location = new System.Drawing.Point(12, 24);
            this.musicBox.Name = "musicBox";
            this.musicBox.Size = new System.Drawing.Size(278, 272);
            this.musicBox.TabIndex = 2;
            this.musicBox.Click += new System.EventHandler(this.MusicBox_Click);
            this.musicBox.SelectedIndexChanged += new System.EventHandler(this.MusicBox_SelectedIndexChanged);
            this.musicBox.DoubleClick += new System.EventHandler(this.MusicBox_DoubleClick);
            // 
            // playBtn
            // 
            this.playBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.playBtn.FlatAppearance.BorderSize = 0;
            this.playBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.playBtn.Location = new System.Drawing.Point(113, 323);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(76, 24);
            this.playBtn.TabIndex = 3;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = false;
            this.playBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // musicProgress
            // 
            this.musicProgress.Location = new System.Drawing.Point(12, 302);
            this.musicProgress.Maximum = 100;
            this.musicProgress.MaximumSize = new System.Drawing.Size(278, 20);
            this.musicProgress.Name = "musicProgress";
            this.musicProgress.Size = new System.Drawing.Size(278, 20);
            this.musicProgress.TabIndex = 6;
            this.musicProgress.TickStyle = System.Windows.Forms.TickStyle.None;
            this.musicProgress.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // musicLenght
            // 
            this.musicLenght.AutoSize = true;
            this.musicLenght.ForeColor = System.Drawing.SystemColors.Control;
            this.musicLenght.Location = new System.Drawing.Point(250, 331);
            this.musicLenght.Name = "musicLenght";
            this.musicLenght.Size = new System.Drawing.Size(40, 16);
            this.musicLenght.TabIndex = 7;
            this.musicLenght.Text = "00:00";
            // 
            // replay
            // 
            this.replay.AutoSize = true;
            this.replay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replay.ForeColor = System.Drawing.SystemColors.Control;
            this.replay.Location = new System.Drawing.Point(12, 329);
            this.replay.Name = "replay";
            this.replay.Size = new System.Drawing.Size(70, 20);
            this.replay.TabIndex = 8;
            this.replay.Text = "Replay";
            this.replay.UseVisualStyleBackColor = true;
            // 
            // volume
            // 
            this.volume.Location = new System.Drawing.Point(231, 369);
            this.volume.Maximum = 100;
            this.volume.MaximumSize = new System.Drawing.Size(60, 20);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(60, 20);
            this.volume.TabIndex = 9;
            this.volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volume.Value = 100;
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.Location = new System.Drawing.Point(2, 380);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(22, 22);
            this.settingsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settingsBtn.TabIndex = 10;
            this.settingsBtn.TabStop = false;
            this.settingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(303, 405);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.replay);
            this.Controls.Add(this.musicLenght);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.musicBox);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.musicProgress);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music Player";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPressed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.musicProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.ListBox musicBox;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.TrackBar musicProgress;
        private System.Windows.Forms.Label musicLenght;
        private System.Windows.Forms.CheckBox replay;
        private System.Windows.Forms.TrackBar volume;
        private System.Windows.Forms.PictureBox settingsBtn;
    }
}

