using System;
using Xunit;
using StringCalculator;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ReturnsZero_WhenInputIsEmptyString()
        {
            var unit = new Calculator();

            var result = unit.Add(string.Empty);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_ReturnsInteger_WhenInputIsASingleNumber()
        {
            var unit = new Calculator();

            var result = unit.Add("8");

            Assert.Equal(8, result);
        }

        [Fact]
        public void Add_ReturnsSum_WhenInputIsTwoNumbers()
        {
            var unit = new Calculator();

            var result = unit.Add("3,4");

            Assert.Equal(7, result);
        }
    }
}
