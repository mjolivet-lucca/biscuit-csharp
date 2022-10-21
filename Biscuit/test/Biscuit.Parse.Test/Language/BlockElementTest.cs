using System;
using System.Runtime.InteropServices;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class BlockElementTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void EmptyString_ShouldNotBeValidBlockElement(string input)
    {
        var isValid = BlockElement.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new BlockElement(input));
    }

    [Fact]
    public void TrimmedBlockElement_ShouldEndWithComma()
    {
        const string input = " aa a; ";

        var isValid = BlockElement.CanParse(input);
        var blockElement = new BlockElement(input);

        Assert.True(isValid);
        Assert.NotNull(blockElement);
    }
}