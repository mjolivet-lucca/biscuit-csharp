using System;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class RuleTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void NullOrEmptyValueIsNotAValidRule(string inputString)
    {
        var isValid = Rule.CanParse(inputString);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Rule(inputString));
    }

    [Fact]
    public void ShouldContainArrowInInputString()
    {
        const string inputString = "aze";

        var isValid = Rule.CanParse(inputString);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Rule(inputString));
    }

    [Theory]
    [InlineData("<-")]
    [InlineData("toto(true)<-")]
    [InlineData("<-toto(true)")]
    public void RuleIsNotValidIfPredicateOrBodyAreNotValid(string inputString)
    {
        var isValid = Rule.CanParse(inputString);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Rule(inputString));
    }
}