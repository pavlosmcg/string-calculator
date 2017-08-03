using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers){
            var delimeters = new char[] {',','\n'};
            if (numbers.IndexOfAny(delimeters) != -1)
                return numbers.Split(delimeters)
                              .Sum(ParseNumber);
            
            return ParseNumber(numbers);
        }

        private int ParseNumber(string number){
            int result;
            int.TryParse(number, out result);
            return result;
        }
    }
}
