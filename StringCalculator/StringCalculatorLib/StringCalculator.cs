﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculatorLib {
    public static class StringCalculator {
        public static int Add(string numbers) {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            // Default delimiters: comma and newline
            char[] delimiters = { ',', '\n' };

            // Check for custom delimiter format
            if (numbers.StartsWith("//")) {
                var customDelimiterMatch = Regex.Match(numbers, @"//(.+?)\n");
                if (customDelimiterMatch.Success) {
                    var customDelimiter = customDelimiterMatch.Groups[1].Value;
                    if (customDelimiter.Length == 1)
                        delimiters = new[] { customDelimiter[0] };
                    else
                        delimiters = customDelimiter.ToCharArray();

                    numbers = numbers.Substring(customDelimiterMatch.Length);
                }
            }

            List<int> numbersArray;
            // Split the string using delimiters and convert to integers
            try {
                numbersArray = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToList();
            }
            catch {
                throw new ArgumentException("Invalid Input");
            }

            // Check for negative numbers and throw an exception
            var negativeNumbers = numbersArray.Where(n => n < 0).ToList();
            if (negativeNumbers.Any()) {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }

            // Ignore numbers greater than 1000
            numbersArray = numbersArray.Where(n => n <= 1000).ToList();

            // Return the sum of the numbers
            return numbersArray.Sum();
        }
    }
}
