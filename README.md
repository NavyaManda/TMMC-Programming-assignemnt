# Vertical Line Counter

## Project Overview

**VerticalLineCounter** is a C# .NET application that analyzes images and counts the number of vertical lines detected in them. It uses image processing to identify black pixels and group consecutive columns with black pixels to determine distinct vertical lines.

### What It Does
- Takes an image file path as input
- Loads the image using SixLabors.ImageSharp
- Scans the image column by column to detect black pixels
- Counts continuous vertical lines (groups of adjacent columns with black pixels)
- Returns the total count of vertical lines found

---

## Prerequisites

- **.NET 10.0 SDK** or later
- **macOS, Windows, or Linux** operating system
- Image files (JPEG, PNG, etc.) to analyze

### Installation

1. Ensure .NET 10.0 is installed:
   ```bash
   dotnet --version
   ```

2. Clone or download the project
---

## Project Structure

```
VerticalLineCounterSolution/
├── README.md
├── .gitignore
├── VerticalLineCounterSolution.sln
├── VerticalLineCounter/               # Main Application
│   ├── Program.cs                     # Entry point
│   ├── VerticalLineCounter.csproj    # Project configuration
│   ├── Services/
│   │   └── LineDetector.cs           # Core line detection logic
│   └── bin/Debug/net10.0/            # Compiled output
└── VerticalLineCounter.Tests/         # Unit Tests
    ├── LineDetectorIntegrationTests.cs
    ├── VerticalLineCounter.Tests.csproj
    ├── imgfiles/                      # Test images
    │   ├── img_1.jpg
    │   ├── img_2.jpg
    │   ├── img_3.jpg
    │   └── img_4.jpg
    └── bin/Debug/net10.0/            # Test compiled output
```

---

## How to Run

### Option 1: Run from Solution Root

Navigate to solution directory and run:

```bash
dotnet run --project VerticalLineCounter "/path/to/image.jpg"
```

Example:
```bash
dotnet run --project VerticalLineCounter "/Users/navyamanda/Downloads/imgfiles/img_4.jpg"
```

### Option 2: Run from Project Directory

```bash
cd VerticalLineCounter
dotnet run "/path/to/image.jpg"
```

### Output

The application will output:
```
Number of vertical lines: X
```

Where `X` is the count of vertical lines detected in the image.

---

## How to Run Tests

### Run All Tests

From the solution root:
```bash
dotnet test VerticalLineCounter.Tests
```

### Run Specific Test

```bash
dotnet test VerticalLineCounter.Tests --filter "CountVerticalLines_ValidImages_ReturnsCorrectCount"
```

### Expected Test Results

The test project includes integration tests with 4 test images:
- `img_1.jpg` - Expected: **1 vertical line**
- `img_2.jpg` - Expected: **3 vertical lines**
- `img_3.jpg` - Expected: **1 vertical line**
- `img_4.jpg` - Expected: **7 vertical lines**

Plus a FileNotFound test that verifies error handling.

---

## Building the Project

### Debug Build
```bash
dotnet build
```

### Release Build
```bash
dotnet build --configuration Release
```

### Clean Build
```bash
dotnet clean
```

---

## Dependencies

- **SixLabors.ImageSharp** v3.1.12 - Image processing library
- **xunit** v2.8.1 - Unit testing framework
- **Microsoft.NET.Test.Sdk** v17.14.1 - Test SDK
- **xunit.runner.visualstudio** v3.1.5 - Test runner for Visual Studio

All dependencies are automatically restored via `dotnet restore`.

---

## Key Files

### Program.cs
Entry point that:
- Accepts image path from command line arguments
- Validates file exists
- Creates LineDetector instance
- Calls CountVerticalLines and outputs result

### LineDetector.cs
Core service containing `CountVerticalLines()` method that:
- Loads image using ImageSharp
- Iterates through each column
- Checks for "near-black" pixels using a threshold-based approach
- Counts transitions from non-black to black columns
- Returns total count

### LineDetectorIntegrationTests.cs
Test class with:
- `[Theory]` tests using `[InlineData]` for multiple image files
- `[Fact]` test for error handling (FileNotFoundException)

---

## Troubleshooting

### "Couldn't find a project to run"
- Make sure you're in the correct directory or use `--project` flag
- Use absolute path: `dotnet run --project /full/path/to/VerticalLineCounter`

### "Directory not found" during tests
- Ensure imgfiles folder exists in `VerticalLineCounter.Tests/imgfiles/`
- Run `dotnet build` to copy test images to output directory

### Image file not found
- Provide absolute path to image file
- Example: `/Users/navyamanda/Downloads/imgfiles/img_4.jpg`

### Test failures
- Rebuild project: `dotnet clean && dotnet build`
- Run tests with verbose output: `dotnet test --logger "console;verbosity=detailed"`

---

## Development Notes

- **Target Framework**: .NET 10.0
- **Language Features**: Implicit usings, Nullable enabled
- **Image Formats Supported**: All formats supported by SixLabors.ImageSharp (JPEG, PNG, BMP, TIFF, etc.)
- **Black Line Detection**: To ensure robustness, the application considers any pixel with RGB values below a specific threshold (default: 10) as "black."

---

## Author

Navya Manda
---

## Contact

Email: Navyaca04@gmail.com
Linkedin: https://www.linkedin.com/in/navya-manda/
