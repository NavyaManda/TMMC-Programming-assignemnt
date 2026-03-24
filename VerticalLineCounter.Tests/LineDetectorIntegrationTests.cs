using System;
using Xunit;
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
                _detector.CountVerticalLines("/invalid/path.jpg"));
        }

        [Theory]
        [InlineData("/VerticalLineCounter.Tests/imgfiles/img_1.jpg", 1)]
        [InlineData("/VerticalLineCounter.Tests/imgfiles/img_2.jpg", 3)]
        [InlineData("/VerticalLineCounter.Tests/imgfiles/img_3.jpg", 1)]
        [InlineData("/VerticalLineCounter.Tests/imgfiles/img_4.jpg", 7)]
        public void CountVerticalLines_ValidImages_ReturnsCorrectCount(string imagePath, int expected)
        {
            // Act
            int result = _detector.CountVerticalLines(imagePath);

            // Assert
            Assert.Equal(expected, result);
        }

}
