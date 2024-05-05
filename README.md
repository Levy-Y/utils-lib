# Utils Library

![Utils Library](https://img.shields.io/badge/language-C%23-blue)

## Introduction

The Utils Library is a collection of utility methods written in C# that i commonly use, to perform common tasks such as mathematical calculations, string formatting, array manipulation, HTTP requests, and more. This library aims to provide convenient and efficient solutions for developers across various C# projects.

## Features

- **Sum**: Calculate the sum of all numbers in an array of integers.
- **Average**: Calculate the average value of numbers in an array.
- **Absolute Value**: Calculate the absolute value of a given float number.
- **Average Absolute Difference**: Calculate the average absolute difference between each number in an array and the average of all numbers.
- **Format Phone Number**: Format a phone number string by removing spaces, dashes, and parentheses, and inserting dashes at specific positions.
- **Find Maximum Element**: Find the maximum element in an array.
- **Reverse Array**: Reverse the order of elements in an array.
- **Factorial**: Calculate the factorial of a non-negative integer.
- **Safe Divide**: Safely divide one double number by another, avoiding division by zero.
- **Make Request**: Make an HTTP request to the specified URL using the specified HTTP method, with optional authentication token inclusion.

## Installation

You can download the latest release of the Utils Library from the [GitHub Releases](https://github.com/Levy-Y/utils-lib/releases) page. Choose the appropriate release package for your project and include the library assembly in your project references.

## Usage

### Example Usage:

```csharp
using utils_lib;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        float[] floatNumbers = { 1.5f, 2.5f, 3.5f, 4.5f, 5.5f };
        string phoneNumber = "(123) 456-7890";
        string url = "https://api.example.com/data";
        string token = "your_auth_token";

        // Calculate sum
        float sum = Utils.Sum(numbers);
        Console.WriteLine("Sum: " + sum);

        // Calculate average
        float avg = Utils.Avg(floatNumbers);
        Console.WriteLine("Average: " + avg);

        // Format phone number
        string formattedPhoneNumber = Utils.FormatPhoneNumber(phoneNumber);
        Console.WriteLine("Formatted Phone Number: " + formattedPhoneNumber);

        // Make HTTP request
        string response = await Utils.MakeRequest(url, HttpMethod.Get, token);
        Console.WriteLine("Response: " + response);
    }
}
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Feel free to submit pull requests, report bugs, or suggest improvements.
