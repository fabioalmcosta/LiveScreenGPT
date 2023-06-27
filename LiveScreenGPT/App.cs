using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveScreenGPT
{
    public partial class App : Form
    {
        public Service _service { get; set; }
        private List<Keys> recordedShortcut;
        private bool hasShortcut = false;
        private SemaphoreSlim captureSemaphore = new SemaphoreSlim(1);
        private System.Windows.Forms.Timer delayTimer = new System.Windows.Forms.Timer();
        private int delaySeconds = 11; // Delay in seconds
        private bool isCheckingScreen = false;

        public App()
        {
            InitializeComponent();

            // Pass the TalkBox control to the Service constructor
            _service = new Service(TalkBox);

            if (!ValidateStart())
                Operate.Enabled = false;

            GetShortcut();

            delayTimer.Interval = 1000; // Timer interval in milliseconds
            delayTimer.Tick += DelayTimer_Tick;

            // Set the form to be always on top
            this.TopMost = true;
        }

        private void GetShortcut()
        {
            string shortcutString = Properties.Settings.Default.Shortcut;
            if (!string.IsNullOrEmpty(shortcutString))
            {
                hasShortcut = true;
                // Split the shortcut string into individual key names
                string[] keyNames = shortcutString.Split(',');

                recordedShortcut = new List<Keys>();
                // Parse each key name and add it to the capturedKeys list
                foreach (string keyName in keyNames)
                {
                    Keys key;
                    if (Enum.TryParse(keyName, out key))
                    {
                        recordedShortcut.Add(key);
                    }
                    else
                    {
                        // Handle the case where a key name could not be parsed
                        // You can show an error message or handle it as needed
                    }
                }
            }
            else
            {
                hasShortcut = false;
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            // Create an instance of the settings form
            Settings settingsForm = new Settings();

            // Subscribe to the FormClosed event of the settings form
            settingsForm.FormClosed += SettingsForm_FormClosed;

            // Show the settings form as a modal dialog
            settingsForm.ShowDialog();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Enable the "Operate" button when the settings form is closed
            if (ValidateStart())
            {
                Operate.Enabled = true;
            }
        }

        private bool isOperating = false;  // Track the operating state

        private async void Operate_Click(object sender, EventArgs e)
        {
            if (ValidateStart())
            {
                if (!isOperating)
                {
                    // Start operating
                    Settings.Enabled = false;
                    isOperating = true;
                    Operate.Text = "Stop";
                    StatusLabel.BackColor = Color.Green;
                    StatusLabel.ForeColor = Color.Green;

                    await CaptureAndProcess();



                    while (isOperating)
                    {
                        if (!isCheckingScreen)
                            if (delaySeconds <= 0 || (hasShortcut && IsKeyPressed(recordedShortcut)))
                                await CaptureAndProcess();

                        await Task.Delay(100);
                    }
                }
                else
                {
                    // Stop operating
                    Settings.Enabled = true;
                    isOperating = false;
                    Operate.Text = "Start";
                    StatusLabel.BackColor = Color.Red;
                    StatusLabel.ForeColor = Color.Red;

                    delayTimer.Stop();
                    delaySeconds = 11;
                    StaLabel.Text = "Stopped";
                }
            }
            else
            {
                this.Settings_Click(sender, e);
            }
        }

        private async Task CaptureAndProcess()
        {
            await captureSemaphore.WaitAsync();
            try
            {
                delayTimer.Stop();
                isCheckingScreen = true;
                StaLabel.Invoke((MethodInvoker)(() => StaLabel.Text = "GPT is checking the screen!"));
                await _service.CaptureAndProcess();
            }
            finally
            {
                captureSemaphore.Release();
                isCheckingScreen = false;
                delayTimer.Start();
                delaySeconds = 11; // Reset the delay time
            }
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            delaySeconds--;

            if (delaySeconds <= 0)
            {
                delayTimer.Stop();
            }
            else
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(delaySeconds);
                string formattedTime = timeSpan.ToString(@"mm\:ss");
                StaLabel.Invoke((MethodInvoker)(() => StaLabel.Text = formattedTime));
            }
        }

        private bool IsKeyPressed(List<Keys> keys)
        {
            foreach (Keys key in keys)
            {
                if ((GetKeyState((int)key) & 0x8000) == 0)
                {
                    return false; // At least one key is not pressed
                }
            }
            return true; // All keys are pressed
        }

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        private bool ValidateStart()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.SelectedMonitor)
                || string.IsNullOrEmpty(Properties.Settings.Default.SelectedLanguage)
                || string.IsNullOrEmpty(Properties.Settings.Default.AICommand)
                || string.IsNullOrEmpty(Properties.Settings.Default.GPTKey)
                || string.IsNullOrEmpty(Properties.Settings.Default.AIJob))
                return false;

            GetShortcut();
            return true;
        }

        private void SaveNotepad_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the text from the textBox control
                string text = TalkBox.Text;

                // Create a temporary file to hold the text
                string tempFilePath = Path.GetTempFileName();

                // Write the text to the temporary file
                File.WriteAllText(tempFilePath, text);

                // Launch Notepad and open the temporary file
                Process.Start("notepad.exe", tempFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening Notepad: " + ex.Message);
            }
        }

        private void LogBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the text from the textBox control
                string text = _service.GetLog();

                // Create a temporary file to hold the text
                string tempFilePath = Path.GetTempFileName();

                // Write the text to the temporary file
                File.WriteAllText(tempFilePath, text);

                // Launch Notepad and open the temporary file
                Process.Start("notepad.exe", tempFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening Notepad: " + ex.Message);
            }
        }

        private void Help_Click(object sender, EventArgs e)
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

        private void App_Shown(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Focus();
            this.TopMost = true;
        }
    }
}
