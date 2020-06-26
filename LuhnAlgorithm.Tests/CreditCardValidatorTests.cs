using System;
using Xunit;

namespace LuhnAlgorithm.Tests
{
    public class CreditCardValidatorTests
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("4539 1488 0343 6467", true)]
        [InlineData("8273 1232 7352 0569", false)]
        [InlineData("350822205683256", true)]
        [InlineData("THIS IS NOT A CREDIT CARD", false)]
        [InlineData("X4539 1488 0343 6467X", false)]
        [InlineData("4539148803436467", true)]
        public void ExerciseCreditCardNumber(string creditNumber, bool expected)
        {
            Assert.Equal(expected, creditNumber.IsValidCreditNumber());
        }
    }
}
