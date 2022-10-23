using System;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class RuleBodyTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void NullOrEmptyStringIsNotAValidRuleBody(string inputString)
    {
        var isValid = RuleBody.CanParse(inputString);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new RuleBody(inputString));
    }

    [Theory]
    [InlineData("toto true")]
    [InlineData("toto (true),,test(t)")]
    public void AllElementsShouldBeValidForARuleBodyToBeValid_InvalidCases(string inputString)
    {
        var isValid = RuleBody.CanParse(inputString);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new RuleBody(inputString));
    }

    [Theory]
    [InlineData("toto(true)", 1)]
    [InlineData("toto(true),test(t)", 2)]
    [InlineData("toto(true),test(t),true", 3)]
    public void AllElementsShouldBeValidForARuleBodyToBeValid_ValidCases(string inputString, int expectedNbElements)
    {
        var isValid = RuleBody.CanParse(inputString);
        var body = new RuleBody(inputString);

        Assert.True(isValid);
        Assert.NotNull(body);
        Assert.NotEmpty(body.RuleBodyElements);
        Assert.Equal(expectedNbElements, body.RuleBodyElements.Count);
    }
}