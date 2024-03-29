﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorLib;
using System;

namespace StringCalculatorLib.Tests {
    [TestClass]
    public class StringCalculatorAddMethodTestSuite {
        // Should always be public and void
        // Testcases should never return anything
        // Create new function to create new testcase
        // Testcase name should represent a scenario
        [TestMethod]
        public void GivenEmptyStringInputZeroIsExpected() {
            // Should Follow AAA

            string input = "";
            int expectedResult = 0;
            // ACT
            int actualResult = StringCalculator.Add(input);
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GivenSingleInputSingleOutputIsExpected() {
            string input = "0";
            int expectedResult = 0;
            int actualResult = StringCalculator.Add(input);
            Assert.AreEqual(expectedResult, actualResult);

            input = "1";
            expectedResult = 1;
            actualResult = StringCalculator.Add(input);
            Assert.AreEqual(expectedResult, actualResult);

            input = "125";
            expectedResult = 125;
            actualResult = StringCalculator.Add(input);
            Assert.AreEqual(expectedResult, actualResult);

            input = "1000";
            expectedResult = 1000;
            actualResult = StringCalculator.Add(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GivenErroneousInputExceptionThrowExpected() {
            string input = "12#42@";
            Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add(input));
            input = "-10,11,12";
            Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add(input));
            input = "//|\n1|2,3|4,5";
            Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add(input));
            input = "//;\n1;2,-3;4;5";
            Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add(input));
            input = "//***\n1,2,3";
            Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add(input));
        }

        [TestMethod]
        public void CustomDelimeterTester() {
            string input = "//|\n1|2|3|4|5";
            int expectedResult = 15;
            int actualResult = StringCalculator.Add(input);
            Assert.AreEqual(expectedResult, actualResult);

            input = "//;\n1;;2";
            expectedResult = 3;
            actualResult = StringCalculator.Add(input);
            Assert.AreEqual(expectedResult, actualResult);

            input = "//###\n1###2###3";
            expectedResult = 6;
            actualResult = StringCalculator.Add(input);
            Assert.AreEqual(expectedResult, actualResult);

            input = "//++\n1++2++3";
            expectedResult = 6;
            actualResult = StringCalculator.Add(input);
            Assert.AreEqual(expectedResult, actualResult);

            input = "//%\n1001%2%3%4%5";
            expectedResult = 14;
            actualResult = StringCalculator.Add(input);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
