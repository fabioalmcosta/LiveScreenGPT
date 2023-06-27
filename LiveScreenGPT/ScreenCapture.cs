using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;

namespace LiveScreenGPT
{
    public class ScreenCapture
    {


        public byte[] CaptureScreen()
        {
            // Get the selected monitor
            Screen selectedMonitor = Screen.AllScreens.FirstOrDefault(monitor => monitor.DeviceName == Properties.Settings.Default.SelectedMonitor);

            if (selectedMonitor == null)
            {
                // Handle the case when the selected monitor is not found
                Console.WriteLine("Selected monitor not found.");
                return null;
            }

            // Get the bounds of the selected monitor
            Rectangle monitorBounds = selectedMonitor.Bounds;

            if (Properties.Settings.Default.Columns)
            {
                // Calculate the new bounds for the left and right sections
                int captureWidth = monitorBounds.Width / 2;
                int captureHeight = monitorBounds.Height;

                // Create bitmaps for left and right sections
                using (Bitmap leftBitmap = new Bitmap(captureWidth, captureHeight))
                using (Bitmap rightBitmap = new Bitmap(captureWidth, captureHeight))
                {
                    // Create graphics objects from bitmaps
                    using (Graphics leftGraphics = Graphics.FromImage(leftBitmap))
                    using (Graphics rightGraphics = Graphics.FromImage(rightBitmap))
                    {
                        // Capture the left section of the screen
                        Rectangle leftCaptureBounds = new Rectangle(monitorBounds.Left, monitorBounds.Top, captureWidth, captureHeight);
                        leftGraphics.CopyFromScreen(leftCaptureBounds.Location, Point.Empty, leftCaptureBounds.Size);

                        // Capture the right section of the screen
                        Rectangle rightCaptureBounds = new Rectangle(monitorBounds.Left + captureWidth, monitorBounds.Top, captureWidth, captureHeight);
                        rightGraphics.CopyFromScreen(rightCaptureBounds.Location, Point.Empty, rightCaptureBounds.Size);
                    }

                    // Combine the left and right images into one
                    using (Bitmap combinedBitmap = new Bitmap(captureWidth, captureHeight * 2))
                    using (Graphics combinedGraphics = Graphics.FromImage(combinedBitmap))
                    {
                        // Draw the left and right images onto the combined bitmap
                        combinedGraphics.DrawImage(leftBitmap, 0, 0);
                        combinedGraphics.DrawImage(rightBitmap, 0, captureHeight);

                        // Convert the combined bitmap to a byte array
                        using (MemoryStream stream = new MemoryStream())
                        {
                            combinedBitmap.Save(stream, ImageFormat.Png);
                            byte[] imageBytes = stream.ToArray();
                            //combinedBitmap.Save("C:/DevPessoal/OutputPath/image.png", ImageFormat.Png);
                            return imageBytes;
                        }
                    }
                }
            }
            else
            {
                // Capture the entire screen as before
                using (Bitmap bitmap = new Bitmap(monitorBounds.Width, monitorBounds.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(monitorBounds.Location, Point.Empty, monitorBounds.Size);
                    }

                    using (MemoryStream stream = new MemoryStream())
                    {
                        bitmap.Save(stream, ImageFormat.Png);
                        byte[] imageBytes = stream.ToArray();
                        //bitmap.Save("C:/DevPessoal/OutputPath/image.png", ImageFormat.Png);
                        return imageBytes;
                    }
                }
            }
        }


        public double CalculateImageSimilarity(byte[] image1, byte[] image2)
        {
            // Convert the byte arrays to images
            using (var bmp1 = (Bitmap)Bitmap.FromStream(new MemoryStream(image1)))
            using (var bmp2 = (Bitmap)Bitmap.FromStream(new MemoryStream(image2)))
            {
                // Ensure the images have the same size
                if (bmp1.Size != bmp2.Size)
                {
                    return 0; // Images are not of the same size, consider them different
                }

                int equalPixels = 0;
                int totalPixels = bmp1.Width * bmp1.Height;

                // Iterate over each pixel and compare their values
                for (int x = 0; x < bmp1.Width; x++)
                {
                    for (int y = 0; y < bmp1.Height; y++)
                    {
                        var pixel1 = bmp1.GetPixel(x, y);
                        var pixel2 = bmp2.GetPixel(x, y);

                        if (pixel1.Equals(pixel2))
                        {
                            equalPixels++;
                        }
                    }
                }

                // Calculate the percentage of equal pixels
                double similarityPercentage = (double)equalPixels / totalPixels;

                return similarityPercentage;
            }
        }


    }
}


