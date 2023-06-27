namespace LiveScreenGPT
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            Screens = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            Languages = new ComboBox();
            Save = new Button();
            label3 = new Label();
            GPTKeyField = new TextBox();
            ErrorMsg = new Label();
            ShortcutBox = new TextBox();
            BtnShortcut = new Button();
            label5 = new Label();
            label8 = new Label();
            ColumnsCheck = new CheckBox();
            label7 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            AIExpertBox = new TextBox();
            AICommandBox = new TextBox();
            TessdataBox = new TextBox();
            label4 = new Label();
            BtnHelp = new Button();
            SuspendLayout();
            // 
            // Screens
            // 
            Screens.Location = new Point(12, 27);
            Screens.Name = "Screens";
            Screens.Size = new Size(132, 23);
            Screens.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 1;
            label1.Text = "Screen to use";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(153, 9);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 2;
            label2.Text = "Language to OCR";
            // 
            // Languages
            // 
            Languages.FormattingEnabled = true;
            Languages.Location = new Point(153, 27);
            Languages.Name = "Languages";
            Languages.Size = new Size(132, 23);
            Languages.TabIndex = 3;
            // 
            // Save
            // 
            Save.Location = new Point(363, 313);
            Save.Name = "Save";
            Save.Size = new Size(131, 23);
            Save.TabIndex = 4;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(329, 244);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 5;
            label3.Text = "GPT Api KEY";
            // 
            // GPTKeyField
            // 
            GPTKeyField.Location = new Point(329, 262);
            GPTKeyField.Name = "GPTKeyField";
            GPTKeyField.Size = new Size(273, 23);
            GPTKeyField.TabIndex = 6;
            // 
            // ErrorMsg
            // 
            ErrorMsg.AutoSize = true;
            ErrorMsg.ForeColor = Color.Red;
            ErrorMsg.Location = new Point(425, 339);
            ErrorMsg.Name = "ErrorMsg";
            ErrorMsg.Size = new Size(0, 15);
            ErrorMsg.TabIndex = 7;
            ErrorMsg.Visible = false;
            // 
            // ShortcutBox
            // 
            ShortcutBox.BorderStyle = BorderStyle.FixedSingle;
            ShortcutBox.Enabled = false;
            ShortcutBox.Location = new Point(11, 242);
            ShortcutBox.Name = "ShortcutBox";
            ShortcutBox.Size = new Size(199, 23);
            ShortcutBox.TabIndex = 11;
            // 
            // BtnShortcut
            // 
            BtnShortcut.BackColor = Color.Green;
            BtnShortcut.FlatAppearance.BorderColor = Color.Red;
            BtnShortcut.FlatAppearance.BorderSize = 0;
            BtnShortcut.FlatStyle = FlatStyle.Popup;
            BtnShortcut.ForeColor = SystemColors.ControlText;
            BtnShortcut.Location = new Point(216, 242);
            BtnShortcut.Name = "BtnShortcut";
            BtnShortcut.Size = new Size(67, 23);
            BtnShortcut.TabIndex = 12;
            BtnShortcut.Text = "Record";
            BtnShortcut.UseVisualStyleBackColor = false;
            BtnShortcut.Click += BtnShortcut_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 224);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 13;
            label5.Text = "Shortcut";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Red;
            label8.Location = new Point(11, 297);
            label8.Name = "label8";
            label8.Size = new Size(266, 45);
            label8.TabIndex = 19;
            label8.Text = "E.g. If you have a question on your screen. is the \r\nquestion on the left and the choices on the right?\r\nOr a document that have a page on both sides.";
            // 
            // ColumnsCheck
            // 
            ColumnsCheck.AutoSize = true;
            ColumnsCheck.Location = new Point(11, 275);
            ColumnsCheck.Name = "ColumnsCheck";
            ColumnsCheck.Size = new Size(187, 19);
            ColumnsCheck.TabIndex = 20;
            ColumnsCheck.Text = "The content has two columns?";
            ColumnsCheck.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 65);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 21;
            label7.Text = "AI Expert";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(329, 13);
            label9.Name = "label9";
            label9.Size = new Size(78, 15);
            label9.TabIndex = 22;
            label9.Text = "AI Command";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Red;
            label10.Location = new Point(12, 82);
            label10.Name = "label10";
            label10.Size = new Size(202, 15);
            label10.TabIndex = 23;
            label10.Text = "E.g. Act as a sotware engineer expert.";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Red;
            label11.Location = new Point(329, 31);
            label11.Name = "label11";
            label11.Size = new Size(305, 90);
            label11.TabIndex = 24;
            label11.Text = resources.GetString("label11.Text");
            // 
            // AIExpertBox
            // 
            AIExpertBox.Location = new Point(11, 106);
            AIExpertBox.Multiline = true;
            AIExpertBox.Name = "AIExpertBox";
            AIExpertBox.Size = new Size(287, 38);
            AIExpertBox.TabIndex = 25;
            // 
            // AICommandBox
            // 
            AICommandBox.Location = new Point(329, 124);
            AICommandBox.Multiline = true;
            AICommandBox.Name = "AICommandBox";
            AICommandBox.Size = new Size(287, 117);
            AICommandBox.TabIndex = 26;
            // 
            // TessdataBox
            // 
            TessdataBox.Location = new Point(11, 186);
            TessdataBox.Name = "TessdataBox";
            TessdataBox.Size = new Size(285, 23);
            TessdataBox.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 168);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 28;
            label4.Text = "Tessdata Location";
            // 
            // BtnHelp
            // 
            BtnHelp.Location = new Point(500, 313);
            BtnHelp.Name = "BtnHelp";
            BtnHelp.Size = new Size(75, 23);
            BtnHelp.TabIndex = 29;
            BtnHelp.Text = "Help ->";
            BtnHelp.UseVisualStyleBackColor = true;
            BtnHelp.Click += BtnHelp_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(641, 363);
            Controls.Add(BtnHelp);
            Controls.Add(label4);
            Controls.Add(TessdataBox);
            Controls.Add(AICommandBox);
            Controls.Add(AIExpertBox);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(ColumnsCheck);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(BtnShortcut);
            Controls.Add(ShortcutBox);
            Controls.Add(ErrorMsg);
            Controls.Add(GPTKeyField);
            Controls.Add(label3);
            Controls.Add(Save);
            Controls.Add(Languages);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Screens);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Screens;
        private Label label1;
        private Label label2;
        private ComboBox Languages;
        private Button Save;
        private Label label3;
        private TextBox GPTKeyField;
        private Label ErrorMsg;
        private TextBox ShortcutBox;
        private Button BtnShortcut;
        private Label label5;
        private Label label8;
        private CheckBox ColumnsCheck;
        private Label label7;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox AIExpertBox;
        private TextBox AICommandBox;
        private TextBox TessdataBox;
        private Label label4;
        private Button BtnHelp;
    }
}