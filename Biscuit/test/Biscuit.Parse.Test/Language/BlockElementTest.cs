using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class BlockElementTest
{
    [Fact]
    public void EmptyString_ShouldNotBeValidBlockElement()
    {
        var blockElement = new BlockElement(string.Empty);

        var isValid = blockElement.IsValid();

        Assert.False(isValid);
    }

    [Fact]
    public void TrimmedBlockElement_ShouldEndWithComma()
    {
        var blockElement = new BlockElement(" aa a; ");

        var isValid = blockElement.IsValid();

        Assert.True(isValid);
    }
}