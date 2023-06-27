using LiveScreenGPT.Data;
using LiveScreenGPT.Helpers;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using System.Net.Http.Headers;
using System.Text;

namespace LiveScreenGPT
{
    public class Service
    {
        private ScreenCapture screenCapture;
        private HttpClient httpClient;
        private readonly string apiRoute = "https://localhost:7070/";
        private FlowLayoutPanel talkBox;  // Reference to the TextBox control for updating the UI
        private StringBuilder logBuilder; // StringBuilder to store log messages
        private OCRHelper oCRHelper;
        private ChatGPTHelper chatGPTHelper;

        public Service(FlowLayoutPanel talkBox)
        {
            screenCapture = new ScreenCapture();
            httpClient = new HttpClient();
            this.talkBox = talkBox;
            logBuilder = new StringBuilder();
            oCRHelper = new OCRHelper();
            chatGPTHelper = new ChatGPTHelper();
            LogMessage("App started...");
        }

        public Service()
        {
            screenCapture = new ScreenCapture();
            httpClient = new HttpClient();
            logBuilder = new StringBuilder();
            oCRHelper = new OCRHelper();
            chatGPTHelper = new ChatGPTHelper();
        }

        private byte[] previousImage;

        public async Task CaptureAndProcess()
        {
            // Capture the screen as a byte array
            byte[] screenImage = screenCapture.CaptureScreen();
            LogMessage("Screen captured.");

            // Compare with the previous image
            if (AreImagesDifferent(screenImage, previousImage))
            {
                LogMessage("Sending image to process data.");

                var textImage = oCRHelper.PerformOCR(screenImage, Properties.Settings.Default.SelectedLanguage);


                // Send the captured image to the POST API and get the result
                string result = await SendImageForProcessing(textImage);

                LogMessage("Result returned.");
                if (!string.IsNullOrEmpty(result))
                {
                    // Deserialize the JSON result to a custom model representing the chat messages
                    LogMessage("Result deserialized.");
                    LogMessage("Result GPT message: " + result);

                    // Display the chat messages in the RichTextBox control
                    talkBox.Invoke((Action)(() =>
                    {
                        // Add GPT message
                        AppendMessage("GPT:", result, Color.Red);
                    }));
                }

                // Update the previous image with the current image
                previousImage = screenImage;
            }
        }

        private bool AreImagesDifferent(byte[] image1, byte[] image2)
        {

            if (image1 == null || image2 == null)
            {
                LogMessage("Images are different.");
                return true;
            }

            if (screenCapture.CalculateImageSimilarity(image1, image2) > 0.9999)
            {
                LogMessage("Images are equal.");
                return false;
            }

            if (image1.SequenceEqual(image2))
            {
                LogMessage("Images are equal.");
                return false;
            }
            else
            {
                LogMessage("Images are different.");
                return true;
            }
        }


        private async Task<string> SendImageForProcessing(string? imageText)
        {
            if (imageText == null)
            {
                return null;
            }

            string imageTextReplace = Properties.Settings.Default.AICommand;

            if (imageTextReplace.Contains("*"))
            {
                imageTextReplace = imageTextReplace.Replace("*", imageText);
            }
            else
            {
                imageTextReplace += imageText;
            }

            var result = await chatGPTHelper.GenerateChatGptResponse(imageTextReplace, Properties.Settings.Default.AIJob);

            return result;
        }

        public void AppendMessage(string message, string sender, Color color)
        {
            if ((string.Equals("Nothing new to search!", message) && talkBox.Text.EndsWith(message)) || string.IsNullOrEmpty(message))
                return;

            // Create a panel to hold the sender and message
            var messagePanel = new RoundedPanel();
            messagePanel.BackColor = Color.FromArgb(30, 30, 30); // Dark background color
            messagePanel.AutoSize = true;
            messagePanel.MaximumSize = new Size(talkBox.Width - 25, 0);

            // Create a label for the sender
            var senderLabel = new Label();
            senderLabel.Text = sender + ":";
            senderLabel.Font = new Font(talkBox.Font, FontStyle.Bold);
            senderLabel.ForeColor = color;
            senderLabel.AutoSize = true;
            senderLabel.BackColor = Color.Transparent;
            senderLabel.MaximumSize = new Size(talkBox.Width - 25, 0);

            // Create a label for the message
            var messageLabel = new Label();
            messageLabel.Text = message;
            messageLabel.AutoSize = true;
            messageLabel.MaximumSize = new Size(talkBox.Width - 25, 0); // Set the maximum width
            messageLabel.ForeColor = Color.White; // White text color
            messageLabel.BackColor = Color.Transparent;

            // Set the position and size of the labels within the panel
            senderLabel.Location = new Point(0, 5);
            messageLabel.Location = new Point(0, senderLabel.Height + 6); // Adjust the vertical position

            // Set the background color and rounded corners for the message panel
            messagePanel.BackColor = Color.LightGray; // Set the desired background color
            messagePanel.Padding = new Padding(10); // Add some padding for the rounded corners
            messagePanel.BorderStyle = BorderStyle.FixedSingle; // Add a border for a cleaner look
            messagePanel.Controls.Add(senderLabel);
            messagePanel.Controls.Add(messageLabel);

            // Add the panel to the chatPanel (assuming chatPanel is the FlowLayoutPanel)
            talkBox.Controls.Add(messagePanel);

            // Scroll to the bottom of the chatPanel
            talkBox.ScrollControlIntoView(messagePanel);
        }

        // Helper method to log messages
        private void LogMessage(string message)
        {
            logBuilder.AppendLine(DateTime.Now.ToString() + ": " + message);
        }

        // Helper method to retrieve the log as a string
        public string GetLog()
        {
            return logBuilder.ToString();
        }
    }
    public class RoundedPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a rounded rectangle path
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Adjust the radius as desired
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            // Set the region of the panel to the rounded rectangle path
            Region = new Region(path);

            // Draw the background color
            Color backgroundColor = Color.FromArgb(30, 30, 30); // Dark background color
            using (SolidBrush brush = new SolidBrush(backgroundColor))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, path);
            }
        }
    }
}
