using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers){
            string input = numbers;
            var delimeters = new char[] {',','\n'};

            var prefixRegex = new Regex(@"\/\/(.*)");
            var prefix = prefixRegex.Match(numbers);

            if (prefix.Success){
                input = numbers.Substring(numbers.IndexOf('\n') + 1);
                var delims = prefix.Groups[1].Value;
                // Single char delimeter syntax:
                if (!delims.Contains('[')) {
                    delimeters = new [] {delims[0]};
                }
                // multiple delimeter and multi-char delimeter syntax:
                else {
                    var delimsRegex = new Regex(@"\[([^\]]*)\]");
                    delimeters = delimsRegex.Matches(delims)
                                            .Cast<Match>()
                                            .Select(m => (m.Groups[1].Value)[0])
                                            .ToArray();
                }
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
