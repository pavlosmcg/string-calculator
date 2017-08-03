using System;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers){
            if (!numbers.Contains(","))
                return ParseNumber(numbers);

            string[] numArray = numbers.Split(',');
            return ParseNumber(numArray[0]) 
                 + ParseNumber(numArray[1]);
        }

        private int ParseNumber(string number){
            int result;
            int.TryParse(number, out result);
            return result;
        }
    }
}
