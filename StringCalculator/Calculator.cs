using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers){
            if (!numbers.Contains(","))
                return ParseNumber(numbers);

            return numbers.Split(',')
                          .Sum(ParseNumber);
        }

        private int ParseNumber(string number){
            int result;
            int.TryParse(number, out result);
            return result;
        }
    }
}
