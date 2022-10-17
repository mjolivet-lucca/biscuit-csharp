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
        var predicate = new LogicalPredicate(input);

        var isValid = predicate.IsValid();

        Assert.False(isValid);
    }
}