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

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("5,6,7", 18)]
        public void Add_ReturnsSumOfAnyNumberOfNumbers(string input, int expected)
        {
            var unit = new Calculator();

            var result = unit.Add(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_ReturnsSumOfNumbers_WhenNewLineIsUsedAsADelimeter()
        {
            var unit = new Calculator();

            var result = unit.Add("3\n4");

            Assert.Equal(7, result);
        }

        [Fact]
        public void Add_ReturnsSumOfNumbers_WhenDelimetersAreAMixtureOfNewLinesAndCommas()
        {
            var unit = new Calculator();

            var result = unit.Add("3\n4,8");

            Assert.Equal(15, result);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//?\n1?2", 3)]
        [InlineData("//&\n1&2", 3)]
        public void Add_ReturnsSumOfNumbers_WhenDelimetersAreChangedUsingSpecialSyntax(string input, int expected)
        {
            var unit = new Calculator();

            var result = unit.Add(input);

            Assert.Equal(expected, result);
        }
    }
}
