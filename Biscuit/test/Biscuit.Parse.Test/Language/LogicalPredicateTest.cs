using System;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class LogicalPredicateTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void NullOrEmptyStringShouldNotParseToPredicate(string input)
    {
        var isValid = LogicalPredicate.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new LogicalPredicate(input));
    }

    [Theory]
    [InlineData("parent test")]
    [InlineData("parent(test")]
    [InlineData("parent test)")]
    public void PredicateShouldContainAtLeastOneOpenParenthesisAndEndWithAClosingParenthesis(string input)
    {
        var isValid = LogicalPredicate.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new LogicalPredicate(input));
    }

    [Fact]
    public void PredicateIsInvalidIfNameIsInvalid()
    {
        const string input = " (test)";
        var isValid = LogicalPredicate.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new LogicalPredicate(input));
    }
    [Theory]
    [InlineData("test()")]
    [InlineData("test(,,)")]
    public void PredicateIsInvalidIftermsAreInvalid(string input)
    {
        var isValid = LogicalPredicate.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new LogicalPredicate(input));
    }

    [Theory]
    [InlineData("test($a)", 1)]
    [InlineData("test(false, 1)", 2)]
    public void CheckValidPredicates(string inputString, int nbTerms)
    {
        var isValid = LogicalPredicate.CanParse(inputString);
        var factTerm = new LogicalPredicate(inputString);

        Assert.True(isValid);
        Assert.NotNull(factTerm);
        Assert.NotNull(factTerm.Name);
        Assert.NotNull(factTerm.Terms);
        Assert.NotEmpty(factTerm.Terms);
        Assert.Equal(nbTerms, factTerm.Terms.Count);
    }
}