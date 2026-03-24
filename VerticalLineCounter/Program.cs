//Console.WriteLine("Hello, World!");

using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


namespace VerticalLineCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
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

            int verticalLineCount = CountVerticalLines(imagePath);
            Console.WriteLine($"Number of vertical lines: {verticalLineCount}");
        }

        static int CountVerticalLines(string imagePath)
        {
            int count = 0;
            using (Image<Rgba32> image = Image.Load<Rgba32>(imagePath))
            {
                int width = image.Width;
                int height = image.Height;
                int mid = height / 2;

                int verticalLines = 0;

                bool previousColumnHadBlack = false;

                for(int x=0; x<width; x++)
                {
                    bool columnHasBlack = false;
                    for(int y=0; y<height; y++)
                    {
                        Rgba32 pixel = image[x, y];
                      if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0)
                        {
                            columnHasBlack = true;
                            break;
                        }
                    }

                    if(columnHasBlack)
                    {
                        if(!previousColumnHadBlack)
                        {
                            verticalLines++;
                        }
                    }

                    previousColumnHadBlack = columnHasBlack;
                }

            count=verticalLines;
                
            }
            return count;
        }

    
    }
}  