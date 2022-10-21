using System;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class RuleTest
{
    [Fact]
    public void ShouldContainArrowInInputString()
    {
        const string inputString = "aze";

        var isValid = Rule.CanParse(inputString);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Rule(inputString));
    }
}