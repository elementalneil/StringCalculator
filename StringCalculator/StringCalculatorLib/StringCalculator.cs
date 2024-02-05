﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculatorLib {
    public static class StringCalculator {
        public static List<int> GenerateNumbersArray(string numbers) {
            // Default delimiters: comma and newline
            string[] delimiters = { ",", "\n" };

            // Check for custom delimiter format
            if (numbers.StartsWith("//")) {
                var customDelimiterMatch = Regex.Match(numbers, @"//(.+?)\n");
                if (customDelimiterMatch.Success) {
                    var customDelimiter = customDelimiterMatch.Groups[1].Value;
                    delimiters = new[] { customDelimiter };

                    numbers = numbers.Substring(customDelimiterMatch.Length);
                }
            }
            else {

            }

            List<int> numbersArray;
            try {
                numbersArray = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToList();
            }
            catch {
                throw new ArgumentException("Invalid Input");
            }

            return numbersArray;
        }

        public static int Add(string numbers) {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            List<int> numbersArray = GenerateNumbersArray(numbers);

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
