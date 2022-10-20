using System;
using Xunit;
using Boolean = Biscuit.Parse.Language.Boolean;

namespace Biscuit.Parse.Test.Language;

public class BooleanTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void EmptyOrNullString_IsNotAValidBoolean(string inputString)
    {
        var isValid = Boolean.CanParse(inputString);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Boolean(inputString));
    }

    [Fact]
    public void TrueIsAValidBooleans()
    {
        const string value = "true";

        var isValid = Boolean.CanParse(value);
        var boolean = new Boolean(value);

        Assert.True(isValid);
        Assert.True(boolean.Value);
    }

    [Fact]
    public void FalseIsAValidBooleans()
    {
        const string value = "false";

        var isValid = Boolean.CanParse(value);
        var boolean = new Boolean(value);

        Assert.True(isValid);
        Assert.False(boolean.Value);
    }

    [Theory]
    [InlineData("TRUE")]
    [InlineData("FALSE")]
    [InlineData("yes")]
    [InlineData("no")]
    [InlineData("1")]
    [InlineData("0")]
    [InlineData("!")]
    [InlineData("!!")]
    public void OtherClassicBooleanWritingsAreNotValidBooleans(string inputString)
    {
        var isValid = Boolean.CanParse(inputString);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Boolean(inputString));
    }
}