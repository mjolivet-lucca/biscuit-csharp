using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class RuleTest
{
    [Fact]
    public void ShouldContainArrowInInputString()
    {
        var inputString = "aze";
        var rule = new Rule(inputString);

        var isValid = rule.IsValid();

        Assert.False(isValid);
    }
}