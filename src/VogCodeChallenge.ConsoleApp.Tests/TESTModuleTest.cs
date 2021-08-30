using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.Shared.Exceptions;
using Xunit;

namespace VogCodeChallenge.ConsoleApp
{
    public class TESTModuleTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void InputIntegerLessThanFiveShouldReturnMultiplyByTwo(int input)
        {
            var output = QuestionClass.TESTModule(input);
            Assert.Equal(input * 2, output);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(2021)]
        [InlineData(34213)]
        [InlineData(4123407)]
        public void InputIntegerBiggerThanFourShouldReturnMultiplyByThree(int input)
        {
            var output = QuestionClass.TESTModule(input);
            Assert.Equal(input * 3, output);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-34213)]
        [InlineData(-4123407)]
        public void InputIntegerLessThanOneShouldThrowException(int input)
        {
            var exception = Record.Exception(() => QuestionClass.TESTModule(input));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The input cannot be less than 1", exception.Message);
        }

        [Fact]
        public void InputFloatOneShouldReturnFloatThree()
        {
            var output = QuestionClass.TESTModule(1.0f);
            Assert.Equal(3.0f, output);
        }

        [Fact]
        public void InputFloatTwoShouldReturnFloatThree()
        {
            var output = QuestionClass.TESTModule(2.0f);
            Assert.Equal(3.0f, output);
        }

        [Theory]
        [InlineData("Hi")]
        [InlineData("The second string")]
        [InlineData("John Smith")]
        [InlineData("Vog")]
        public void InputStringShouldReturnUpperCase(string input)
        {
            var output = QuestionClass.TESTModule(input);
            Assert.Equal(input.ToUpper(), output);
        }

        [Theory]
        [InlineData(1.25)]
        [InlineData(-1.25)]
        [InlineData(0.43f)]
        [InlineData(0.431234d)]
        public void OtherInputShouldReturnTheSameAsInput(dynamic input)
        {
            var output = QuestionClass.TESTModule(input);
            Assert.Equal(input, output);
        }

    }
}
