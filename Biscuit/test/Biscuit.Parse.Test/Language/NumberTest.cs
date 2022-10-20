using System;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class NumberTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void NullOrEmptyStringIsNotAValidNumber(string inputString)
    {
        var isValid = Number.CanParse(inputString);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Number(inputString));
    }

    [Theory]
    [InlineData("1,2")]
    [InlineData("3.4")]
    public void DecimalDataIsNotAValidNumber(string inputString)
    {
        var isValid = Number.CanParse(inputString);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Number(inputString));
    }

    [Fact]
    public void NegativeNumberIsValid()
    {
        const string value = "-12";

        var isValid = Number.CanParse(value);
        var number = new Number(value);

        Assert.True(isValid);
        Assert.Equal(-12, number.Value);
    }

    [Fact]
    public void PositiveNumberIsValid()
    {
        const string value = "42";

        var isValid = Number.CanParse(value);
        var number = new Number(value);

        Assert.True(isValid);
        Assert.Equal(42, number.Value);
    }
}