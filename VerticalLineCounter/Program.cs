using VerticalLineCounter.Services;


namespace VerticalLineCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Validate command-line arguments
                if(args.Length != 1)
                {
                    Console.WriteLine("Please provide the path to the image file.");
                    return;
                }
            
            

            string imagePath = args[0];

            // Validate that the file exists before processing   
            if (!File.Exists(imagePath))
                {
                    Console.WriteLine("Error: File not found - " + imagePath);
                    return;
                }

            var detector = new LineDetector();
            int verticalLineCount = detector.CountVerticalLines(imagePath);

            // Output the result to the console
            Console.WriteLine($"Number of vertical lines: {verticalLineCount}");

            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    
    }
}  