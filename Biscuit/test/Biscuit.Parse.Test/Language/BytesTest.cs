using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class BytesTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void NullOrEmptyStringIsNotValidBytes(string inputString)
    {
        var bytes = new Bytes(inputString);

        var isValid = bytes.IsValid();

        Assert.False(isValid);
        Assert.Empty(bytes.Value);
    }

    [Fact]
    public void BytesShouldStartWithHex()
    {
        var bytes = new Bytes("test");

        var isValid = bytes.IsValid();

        Assert.False(isValid);
        Assert.Empty(bytes.Value);
    }

    [Theory]
    [InlineData("g")]
    [InlineData("h")]
    [InlineData("i")]
    [InlineData("j")]
    [InlineData("k")]
    [InlineData("l")]
    [InlineData("m")]
    [InlineData("n")]
    [InlineData("o")]
    [InlineData("p")]
    [InlineData("q")]
    [InlineData("r")]
    [InlineData("s")]
    [InlineData("t")]
    [InlineData("u")]
    [InlineData("v")]
    [InlineData("w")]
    [InlineData("x")]
    [InlineData("y")]
    [InlineData("z")]
    public void HexDataShouldNotContainInvalidLetter(string invalidLetter)
    {
        var bytes = new Bytes($"hex:1a${invalidLetter}");

        var isValid = bytes.IsValid();

        Assert.False(isValid);
        Assert.Empty(bytes.Value);
    }

    [Fact]
    public void ValidHexDataShouldBeReadable()
    {
        var bytes = new Bytes("hex:1a223e");

        var isValid = bytes.IsValid();

        Assert.True(isValid);
        Assert.Equal("1a223e", bytes.Value);
    }
}