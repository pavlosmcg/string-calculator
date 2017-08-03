using System;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers){
            int result;
            int.TryParse(numbers, out result);
            return result;
        }
    }
}
