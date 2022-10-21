using System;
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
        var isValid = FactTerm.CanParse(inputString);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new FactTerm(inputString));
    }

    [Theory]
    [InlineData("true")]
    [InlineData("false")]
    public void BooleanShouldBeValidFactTerm(string inputString)
    {
        var isValid = FactTerm.CanParse(inputString);
        var factTerm = new FactTerm(inputString);

        Assert.True(isValid);
        Assert.NotNull(factTerm);
    }
}