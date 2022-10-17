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
        var number = new Number(inputString);

        var isValid = number.IsValid();

        Assert.False(isValid);
        Assert.Equal(0, number.Value);
    }
    [Theory]
    [InlineData("1,2")]
    [InlineData("3.4")]
    public void DecimalDataIsNotAValidNumber(string inputString)
    {
        var number = new Number(inputString);

        var isValid = number.IsValid();

        Assert.False(isValid);
        Assert.Equal(0, number.Value);
    }

    [Fact]
    public void NegativeNumberIsValid()
    {
        var number = new Number("-12");

        var isValid = number.IsValid();

        Assert.True(isValid);
        Assert.Equal(-12, number.Value);
    }

    [Fact]
    public void PositiveNumberIsValid()
    {
        var number = new Number("42");

        var isValid = number.IsValid();

        Assert.True(isValid);
        Assert.Equal(42, number.Value);
    }
}