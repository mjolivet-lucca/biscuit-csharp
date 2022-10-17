using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class FactTermTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void FactTermShouldNotBeValid_WhenGivenEmptySpaceOrNull(string inputString)
    {
        var factTerm = new FactTerm(inputString);

        var isValid = factTerm.IsValid();

        Assert.False(isValid);
    }

    [Theory]
    [InlineData("true")]
    [InlineData("false")]
    public void BooleanShouldBeValidFactTerm(string inputString)
    {
        var factTerm = new FactTerm(inputString);

        var isValid = factTerm.IsValid();

        Assert.True(isValid);
    }
}