using System;
using Xunit;
using StringCalculator;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_Returns_ZeroForEmptyString()
        {
            var unit = new Calculator();

            var result = unit.Add(string.Empty);

            Assert.Equal(0, result);
        }
    }
}
