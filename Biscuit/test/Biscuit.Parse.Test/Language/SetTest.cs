using System;
using System.Linq;
using Biscuit.Parse.Language;
using Xunit;
using String = Biscuit.Parse.Language.String;

namespace Biscuit.Parse.Test.Language;

public class SetTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void NullOrEmptyStringIsNotAValidSet(string inputData)
    {
        var isValid = Set.CanParse(inputData);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Set(inputData));
    }

    [Fact]
    public void SetShouldNotBeValidWhenNotSurroundedWithBrackets()
    {
        var inputData = "false";
        var isValid = Set.CanParse(inputData);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Set(inputData));
    }

    [Theory]
    [InlineData("[false]", 1)]
    [InlineData("[ false ]", 1)]
    [InlineData("[ false, true ]", 2)]
    [InlineData("[ false, 1, hex:12a0 ]", 3)]
    public void SetShouldBeValidWhenContainingOneOrMultipleSetTerms(string inputData, int expectedAmountOfTerms)
    {
        var isValid = Set.CanParse(inputData);
        var set = new Set(inputData);

        Assert.True(isValid);
        Assert.NotEmpty(set.Value);
        Assert.Equal(expectedAmountOfTerms, set.Value.Count);
        Assert.True(set.Value.All(v => v.GetType() != typeof(String)));
    }

}