using LiveScreenGPT.Data;
using System.Windows.Forms;

namespace LiveScreenGPT
{
    internal static class Program
    {
        // Global variable to store the available languages
        public static List<Language> AvailableLanguages = new List<Language>();
        public static List<string> AvailableMonitors = new List<string>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Create an instance of the Service class
            Service service = new Service();

            try
            {
                // Call the GetAvailableLanguages function and store the result in the global variable
                AvailableLanguages.AddRange(new List<Language>
                {
                    new Language { Id = "en", Code = "eng", Name = "English" },
                    new Language { Id = "es", Code = "es", Name = "Spanish" },
                    new Language { Id = "fr", Code = "fr", Name = "French" },
                    new Language { Id = "it", Code = "it", Name = "Italian" },
                    new Language { Id = "pt", Code = "por", Name = "Portuguese" }
                });

                // Populate the ComboBox with available monitors
                if (Screen.AllScreens != null)
                {
                    foreach (var screen in Screen.AllScreens)
                    {
                        AvailableMonitors.Add(screen.DeviceName);
                    }
                }
            }
            catch (Exception)
            {


            }

            Application.Run(new App());
        }
    }
}
