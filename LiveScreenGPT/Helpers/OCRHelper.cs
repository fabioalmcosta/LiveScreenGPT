using Tesseract;

namespace LiveScreenGPT.Helpers
{
    public class OCRHelper
    {
        public string PerformOCR(string imagePath, string lang)
        {
            using (var engine = new TesseractEngine(Properties.Settings.Default.Tessdata, lang, EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();
                        return text;
                    }
                }
            }
        }

        public string PerformOCR(byte[] imagePath, string lang)
        {
            using (var engine = new TesseractEngine(Properties.Settings.Default.Tessdata, lang, EngineMode.Default))
            {
                using (var img = Pix.LoadFromMemory(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();
                        return text;
                    }
                }
            }
        }
    }
}
