using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using StringCalculatorLib;

namespace StringCalculatorLib {
    class Program {
        public static void Main() {
            String input;
            int output;

            input = Console.ReadLine();
            output = StringCalculator.Add(input);

            Console.WriteLine(output);
        }
    }
}
