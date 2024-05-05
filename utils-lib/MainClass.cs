using System.Text.Json;
using System.Text.RegularExpressions;

namespace utils_lib
{
    public class Utils
    {
        /// <summary>
        /// Calculates the sum of all numbers in an array of integers.
        /// </summary>
        /// <param name="numbers">The array of integers.</param>
        /// <returns>The sum of all numbers in the array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
        public static float Sum(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            } else
            {
                int numsSum = 0;

                foreach (var number in numbers) 
                {
                    numsSum += number;
                }

                return numsSum;
            }
        }

        /// <summary>
        /// Calculates the average value of numbers in an array.
        /// </summary>
        /// <param name="nums">The array of numbers.</param>
        /// <returns>The average value of the numbers in the array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
        public static float Avg(float[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            } else
            {
                float sums = 0;
                foreach(var number in nums)
                {
                    sums += number;
                }

                return sums / nums.Length;
            }
        }

        /// <summary>
        /// Calculates the absolute value of a given float number.
        /// </summary>
        /// <param name="num">The input number.</param>
        /// <returns>The absolute value of the input number.</returns>
        public static float Abs(float num)
        {
            if (num < 0)
            {
                return -num;
            } else
            {
                return num;
            }
        }

        /// <summary>
        /// Calculates the average absolute difference between each number in an array and the average of all numbers in the array.
        /// </summary>
        /// <param name="nums">The array of numbers.</param>
        /// <returns>The average absolute difference.</returns>
        public static float AvgAbsDiff(float[] nums)
        {
            float avg = Avg(nums);
            float result_1 = 0;

            foreach (var number in nums)
            {
                result_1 += Abs(number -  avg);
            }

            return result_1/nums.Length;
        }

        /// <summary>
        /// Formats a phone number string by removing spaces, dashes, and parentheses, and inserting dashes at specific positions.
        /// </summary>
        /// <param name="input">The input phone number string.</param>
        /// <returns>The formatted phone number string.</returns>
        public static string FormatPhoneNumber(string input)
        {
            var formatted = Regex.Replace(input, @"[\s\-\(\)]", "");
            return formatted.Insert(3, "-").Insert(6, "-").Insert(10, "-");
        }

        /// <summary>
        /// Finds the maximum element in an array.
        /// This method iterates through the provided array and compares each element to determine the maximum value.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array. Must implement the IComparable interface.</typeparam>
        /// <param name="array">The array to search for the maximum element.</param>
        /// <returns>The maximum element found in the array.</returns>
        /// <exception cref="ArgumentException">Thrown when the array is empty, indicating that there is no maximum element to return.</exception>
        public static T FindMaxElement<T>(T[] array) where T : IComparable<T>
        {
            if (array.Length == 0) throw new ArgumentException("Array is empty.");

            T max = array[0];
            foreach (var item in array)
            {
                if (item.CompareTo(max) > 0) max = item;
            }
            return max;
        }

        /// <summary>
        /// Reverses the order of elements in an array.
        /// This method swaps elements from the start and end of the array, moving towards the center, until the entire array is reversed.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array to be reversed.</param>
        /// <exception cref="ArgumentException">Thrown when the array is null, indicating that the operation cannot be performed on a null array.</exception>
        public static void ReverseArray<T>(T[] array)
        {
            int start = 0;
            int end = array.Length - 1;

            while (start < end)
            {
                T temp = array[start];
                array[start] = array[end];
                array[end] = temp;

                start++;
                end--;
            }
        }

        /// <summary>
        /// Calculates the factorial of a non-negative integer.
        /// </summary>
        /// <param name="number">The non-negative integer for which to calculate the factorial.</param>
        /// <returns>The factorial of the given non-negative integer.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the input number is negative.</exception>
        public static long Factorial(int number)
        {
            if (number < 0) throw new ArgumentOutOfRangeException(nameof(number), "Factorial is not defined for negative numbers.");

            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// Safely divides one double number by another, avoiding division by zero.
        /// </summary>
        /// <param name="dividend">The number to be divided.</param>
        /// <param name="divisor">The number by which the dividend is to be divided.</param>
        /// <returns>The result of dividing the dividend by the divisor, or 0 if the divisor is 0.</returns>
        public static double SafeDivide(double dividend, double divisor)
        {
            if (divisor == 0) return 0;
            return dividend / divisor;
        }

        /// <summary>
        /// Makes an HTTP request to the specified URL using the specified HTTP method, and optionally includes an authentication token in the request header.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the JSON response into.</typeparam>
        /// <param name="url">The URL to make the request to.</param>
        /// <param name="method">The HTTP method to use for the request (GET or POST).</param>
        /// <param name="token">The authentication token to include in the request header, if applicable.</param>
        /// <returns>The deserialized JSON response as an object of the specified type.</returns>
        /// <exception cref="HttpRequestException">Thrown when an error occurs while making the HTTP request.</exception>
        /// <exception cref="JsonException">Thrown when an error occurs during JSON deserialization.</exception>
        public static async Task<string> MakeRequest(string url, HttpMethod method, string token = "")
        {
            using (HttpClient client = new())
            {
                using (HttpRequestMessage request = new(method, url))
                {
                    if (method == HttpMethod.Post)
                    {
                        request.Headers.Add("Authentication", token);
                    }

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();

                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }
        }
    }
}