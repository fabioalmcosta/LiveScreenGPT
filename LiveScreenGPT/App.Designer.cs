namespace LiveScreenGPT
{
    partial class App
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
            Settings = new Button();
            Operate = new Button();
            SaveNotepad = new Button();
            LogBtn = new Button();
            StatusLabel = new Label();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            StaLabel = new Label();
            TalkBox = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // Settings
            // 
            Settings.Location = new Point(110, 12);
            Settings.Name = "Settings";
            Settings.Size = new Size(75, 23);
            Settings.TabIndex = 0;
            Settings.Text = "Settings";
            Settings.UseVisualStyleBackColor = true;
            Settings.Click += Settings_Click;
            // 
            // Operate
            // 
            Operate.Location = new Point(29, 12);
            Operate.Name = "Operate";
            Operate.Size = new Size(75, 23);
            Operate.TabIndex = 1;
            Operate.Text = "Start";
            Operate.UseVisualStyleBackColor = true;
            Operate.Click += Operate_Click;
            // 
            // SaveNotepad
            // 
            SaveNotepad.Location = new Point(191, 12);
            SaveNotepad.Name = "SaveNotepad";
            SaveNotepad.Size = new Size(48, 23);
            SaveNotepad.TabIndex = 2;
            SaveNotepad.Text = "TXT";
            SaveNotepad.UseVisualStyleBackColor = true;
            SaveNotepad.Click += SaveNotepad_Click;
            // 
            // LogBtn
            // 
            LogBtn.Location = new Point(245, 12);
            LogBtn.Name = "LogBtn";
            LogBtn.RightToLeft = RightToLeft.No;
            LogBtn.Size = new Size(48, 23);
            LogBtn.TabIndex = 6;
            LogBtn.Text = "LOG";
            LogBtn.UseVisualStyleBackColor = true;
            LogBtn.Click += LogBtn_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.BackColor = Color.Red;
            StatusLabel.BorderStyle = BorderStyle.FixedSingle;
            StatusLabel.Enabled = false;
            StatusLabel.ForeColor = Color.Transparent;
            StatusLabel.Location = new Point(5, 15);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.RightToLeft = RightToLeft.No;
            StatusLabel.Size = new Size(18, 17);
            StatusLabel.TabIndex = 7;
            StatusLabel.Text = "O";
            // 
            // button1
            // 
            button1.Location = new Point(299, 12);
            button1.Name = "button1";
            button1.Size = new Size(48, 23);
            button1.TabIndex = 8;
            button1.Text = "Help";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Help_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(239, 301);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 9;
            label1.Text = "2023 Live Screen GPT!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(4, 301);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 10;
            label2.Text = "Status:";
            // 
            // StaLabel
            // 
            StaLabel.AutoSize = true;
            StaLabel.ForeColor = Color.White;
            StaLabel.Location = new Point(51, 302);
            StaLabel.Name = "StaLabel";
            StaLabel.Size = new Size(0, 15);
            StaLabel.TabIndex = 11;
            // 
            // TalkBox
            // 
            TalkBox.AutoScroll = true;
            TalkBox.Location = new Point(5, 41);
            TalkBox.Name = "TalkBox";
            TalkBox.Size = new Size(342, 257);
            TalkBox.TabIndex = 12;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(359, 323);
            Controls.Add(TalkBox);
            Controls.Add(StaLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(StatusLabel);
            Controls.Add(LogBtn);
            Controls.Add(SaveNotepad);
            Controls.Add(Operate);
            Controls.Add(Settings);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "App";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "2023 Live Screen GPT";
            TopMost = true;
            Shown += App_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Settings;
        private Button Operate;
        private Button SaveNotepad;
        private Button LogBtn;
        private Label StatusLabel;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label StaLabel;
        private FlowLayoutPanel TalkBox;
    }
}