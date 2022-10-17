using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class BooleanTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void EmptyOrNullString_IsNotAValidBoolean(string inputString)
    {
        var boolean = new Boolean(inputString);

        var isValid = boolean.IsValid();

        Assert.False(isValid);
        Assert.False(boolean.Value);
    }

    [Fact]
    public void TrueIsAValidBooleans()
    {
        var boolean = new Boolean("true");

        var isValid = boolean.IsValid();

        Assert.True(isValid);
        Assert.True(boolean.Value);
    }

    [Fact]
    public void FalseIsAValidBooleans()
    {
        var boolean = new Boolean("false");

        var isValid = boolean.IsValid();

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
        var boolean = new Boolean(inputString);

        var isValid = boolean.IsValid();

        Assert.False(isValid);
        Assert.False(boolean.Value);
    }
}