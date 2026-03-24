using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace VerticalLineCounter.Services
{
    public class LineDetector
    {
        public  int CountVerticalLines(string imagePath)
        {
            int count = 0;

            // Load the image into memory using ImageSharp
            using (Image<Rgba32> image = Image.Load<Rgba32>(imagePath))
            {
                int width = image.Width;
                int height = image.Height;

                int verticalLines = 0;

                // Tracks whether the previous column contained any black pixel
                bool previousColumnHadBlack = false;

                for(int x=0; x<width; x++)
                {
                    bool columnHasBlack = false;

                    for(int y=0; y<height; y++)
                    {
                        Rgba32 pixel = image[x, y];

                    // Check if the pixel is pure black
                    if (pixel.R < 10 && pixel.G < 10 && pixel.B < 10)
                        {
                            columnHasBlack = true;
                            break;
                        }
                    }

                    // If current column has black pixels increase the count of vertical lines 
                    // if previous column did not have black pixels,
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