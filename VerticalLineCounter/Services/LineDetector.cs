using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace VerticalLineCounter.Services
{
    public class LineDetector
    {
        public  int CountVerticalLines(string imagePath)
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