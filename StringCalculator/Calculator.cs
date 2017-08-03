using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers){
            string input = numbers;
            var delimeters = new char[] {',','\n'};

            if (numbers.StartsWith("//")) {
                input = numbers.Substring(4);
                delimeters = new char[] { numbers[2] };
            }

            int[] parsed;
            if (input.IndexOfAny(delimeters) != -1)
                 parsed = input.Split(delimeters)
                               .Select(ParseNumber)
                               .ToArray();
            else 
                parsed = new [] {ParseNumber(input)};
            
            var negatives = parsed.Where(i => i < 0);
            if (negatives.Any())
                throw new ArgumentOutOfRangeException(
                    negatives.Aggregate(
                        "Negatives not allowed:",
                        (n,str) => $"{str} {n},",
                        res => res.Substring(0,res.Length-1))
                );

            return parsed.Sum();
        }

        private int ParseNumber(string number){
            int result;
            int.TryParse(number, out result);
            return result;
        }
    }
}
