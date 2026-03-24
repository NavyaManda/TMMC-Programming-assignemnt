using System;
using Xunit;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using VerticalLineCounter.Services;
namespace VerticalLineCounter.Tests;

public class LineDetectorIntegrationTests
{
    private readonly LineDetector _detector;

        public LineDetectorIntegrationTests()
        {
            _detector = new LineDetector();
        }


        // Invalid file path test
        [Fact]
        public void CountVerticalLines_FileNotFound_ThrowsException()
        {
            Assert.Throws<System.IO.FileNotFoundException>(() =>
                _detector.CountVerticalLines("path.jpg"));
        }

        [Theory]
        [InlineData("img_1.jpg", 1)]
        [InlineData("img_2.jpg", 3)]
        [InlineData("img_3.jpg", 1)]
        [InlineData("img_4.jpg", 7)]
        public void CountVerticalLines_ValidImages_ReturnsCorrectCount(string imagePath, int expected)
        {

            // Arrange
            var testDir = Path.GetDirectoryName(typeof(LineDetectorIntegrationTests).Assembly.Location) ?? string.Empty;
            string fullPath = Path.Combine(testDir, "imgfiles", imagePath);



            // Act
            int result = _detector.CountVerticalLines(fullPath);

            // Assert
            Assert.Equal(expected, result);
           
        }

}
