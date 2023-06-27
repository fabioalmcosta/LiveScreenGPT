using LiveScreenGPT.Data;



namespace LiveScreenGPT
{
    public partial class Settings : Form
    {
        private bool isRecordingShortcut;
        private List<Keys> capturedKeys;

        public Settings()
        {
            InitializeComponent();

            // Set the DropDownStyle property to DropDownList
            Screens.DropDownStyle = ComboBoxStyle.DropDownList;
            Languages.DropDownStyle = ComboBoxStyle.DropDownList;

            // Populate the ComboBox with available monitors
            foreach (var screen in Program.AvailableMonitors)
            {
                Screens.Items.Add(screen);
            }

            // Set the selected monitor from the saved setting
            if (Program.AvailableMonitors.Any(x => x == Properties.Settings.Default.SelectedMonitor))
                Screens.SelectedItem = Properties.Settings.Default.SelectedMonitor;

            foreach (var lang in Program.AvailableLanguages)
            {
                Languages.Items.Add(lang);
            }

            // Set the selected language from the saved setting
            var selectedLanguage = Properties.Settings.Default.SelectedLanguage;
            if (Program.AvailableLanguages.Any(x => x.Code == selectedLanguage))
            {
                Languages.SelectedItem = Program.AvailableLanguages.First(x => x.Code == selectedLanguage);
            }


            GPTKeyField.Text = Properties.Settings.Default.GPTKey;
            AIExpertBox.Text = Properties.Settings.Default.AIJob;
            AICommandBox.Text = Properties.Settings.Default.AICommand;
            TessdataBox.Text = Properties.Settings.Default.Tessdata;

            ShortcutBox.Text = !string.IsNullOrEmpty(Properties.Settings.Default.Shortcut) ? Properties.Settings.Default.Shortcut.Replace(",", "+") : string.Empty;
            ColumnsCheck.Checked = Properties.Settings.Default.Columns;

            // Set the form to be always on top
            this.TopMost = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Languages.SelectedItem == null
                || Screens.SelectedItem == null
                || string.IsNullOrEmpty(AIExpertBox.Text)
                || string.IsNullOrEmpty(GPTKeyField.Text)
                || string.IsNullOrEmpty(AICommandBox.Text)
                || string.IsNullOrEmpty(TessdataBox.Text))
            {
                ErrorMsg.Text = "All fields are required!";
                ErrorMsg.Visible = true;
            }
            else
            {
                ErrorMsg.Text = "";
                ErrorMsg.Visible = false;

                var selecLang = (Language)Languages.SelectedItem;

                // Save the selected monitor and language as application settings
                Properties.Settings.Default.SelectedMonitor = Screens.SelectedItem.ToString();
                Properties.Settings.Default.SelectedLanguage = selecLang.Code.ToString();
                Properties.Settings.Default.AIJob = AIExpertBox.Text;
                Properties.Settings.Default.GPTKey = GPTKeyField.Text;
                Properties.Settings.Default.Columns = ColumnsCheck.Checked;
                Properties.Settings.Default.AICommand = AICommandBox.Text;
                Properties.Settings.Default.Tessdata = TessdataBox.Text;


                if (capturedKeys != null && capturedKeys.Any())
                    Properties.Settings.Default.Shortcut = string.Join(",", capturedKeys.Select(k => k.ToString()));

                Properties.Settings.Default.Save();

                this.Close();
            }
        }
        private void BtnShortcut_Click(object sender, EventArgs e)
        {
            if (isRecordingShortcut)
            {
                // Stop recording the shortcut
                StopRecordingShortcut();
            }
            else
            {
                // Start recording the shortcut
                StartRecordingShortcut();
            }
        }

        private void StartRecordingShortcut()
        {
            isRecordingShortcut = true;
            BtnShortcut.Text = "Stop";
            BtnShortcut.BackColor = Color.Red;
            ShortcutBox.ResetText();

            // Clear any previously captured keys
            capturedKeys = new List<Keys>();

            // Enable keyboard capture
            KeyPreview = true;
            KeyDown += ShortcutForm_KeyDown;
            KeyUp += ShortcutForm_KeyUp;
        }

        private void StopRecordingShortcut()
        {
            isRecordingShortcut = false;
            BtnShortcut.Text = "Record";
            BtnShortcut.BackColor = Color.Green;

            // Disable keyboard capture
            KeyPreview = false;
            KeyDown -= ShortcutForm_KeyDown;
            KeyUp -= ShortcutForm_KeyUp;

            // Save the captured shortcut
            SaveShortcut();
        }

        private void ShortcutForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Add the pressed key to the capturedKeys list
            if (!capturedKeys.Contains(e.KeyCode))
            {

                // Display the pressed key in the ShortcutBox
                if (capturedKeys.Count() > 0)
                    ShortcutBox.AppendText(" + ");

                ShortcutBox.AppendText(e.KeyCode.ToString());

                capturedKeys.Add(e.KeyCode);
            }
        }

        private void ShortcutForm_KeyUp(object sender, KeyEventArgs e)
        {
            // Remove the released key from the capturedKeys list
            //if (capturedKeys.Contains(e.KeyCode))
            //{
            //    capturedKeys.Remove(e.KeyCode);
            //}
        }

        private void SaveShortcut()
        {
            // Create a string representation of the captured key combination
            string shortcut = string.Join(",", capturedKeys.Select(k => k.ToString()));

            // Save the captured shortcut for later use
            // You can store it in Properties.Settings.Default.Shortcut or any other desired location
            Properties.Settings.Default.Shortcut = shortcut;
            Properties.Settings.Default.Save();
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/fabioalmcosta/LiveScreenGPT/tree/main#readme";

            // Open the website in the default browser
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };

            System.Diagnostics.Process.Start(psi);
        }
    }
}
