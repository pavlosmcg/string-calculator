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

            if (input.IndexOfAny(delimeters) != -1)
                return input.Split(delimeters)
                            .Sum(ParseNumber);
            
            return ParseNumber(input);
        }

        private int ParseNumber(string number){
            int result;
            int.TryParse(number, out result);
            return result;
        }
    }
}
