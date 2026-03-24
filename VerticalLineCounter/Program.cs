//Console.WriteLine("Hello, World!");

using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using VerticalLineCounter.Services;


namespace VerticalLineCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                if(args.Length != 1)
                {
                    Console.WriteLine("Please provide the path to the image file.");
                    return;
                }
            
            

            string imagePath = args[0];
            
            if (!File.Exists(imagePath))
                {
                    Console.WriteLine("Error: File not found - " + imagePath);
                    return;
                }

            var detector = new LineDetector();
            int verticalLineCount = detector.CountVerticalLines(imagePath);
            Console.WriteLine($"Number of vertical lines: {verticalLineCount}");
            
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    
    }
}  