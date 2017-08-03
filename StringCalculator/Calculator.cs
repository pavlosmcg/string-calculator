using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers){
            string input = numbers;
            var delimeters = new char[] {',','\n'};

            // multi char delimeter syntax
            if (numbers.StartsWith("//[")){
                int inputIndex = numbers.IndexOf('\n') + 1;
                input = numbers.Substring(inputIndex);
                delimeters = new char[] { numbers[3] };
            }
            // single char delimeter syntax
            else if (numbers.StartsWith("//")) {
                input = numbers.Substring(4);
                delimeters = new char[] { numbers[2] };
            }

            IEnumerable<int> parsed = 
                ParseInputString(input, delimeters)
                .Where(i => i <= 1000);
            
            CheckForNegatives(parsed);

            return parsed.Sum();
        }

        private int[] ParseInputString(string input, char[] delimeters) {
            if (input.IndexOfAny(delimeters) != -1)
                 return input.Split(delimeters)
                             .Select(ParseNumber)
                             .ToArray();
            return new [] {ParseNumber(input)};
        }

        private int ParseNumber(string number){
            int result;
            int.TryParse(number, out result);
            return result;
        }

        private void CheckForNegatives(IEnumerable<int> input) {
            var negatives = input.Where(i => i < 0);
            if (negatives.Any())
                throw new ArgumentOutOfRangeException(
                    negatives.Aggregate(
                        "Negatives not allowed:",
                        (n,str) => $"{str} {n},",
                        res => res.Substring(0,res.Length-1))
                );
        }
    }
}
