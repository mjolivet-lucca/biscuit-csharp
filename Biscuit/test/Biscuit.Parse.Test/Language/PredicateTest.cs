using System;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class PredicateTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void EmptyPredicateShouldNotBeValid(string input)
    {
        var isValid = LogicalPredicate.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new LogicalPredicate(input));
    }
}