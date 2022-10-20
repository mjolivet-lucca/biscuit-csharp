using System;
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
        var isValid = Bytes.CanParse(inputString);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Bytes(inputString));
    }

    [Fact]
    public void BytesShouldStartWithHex()
    {
        const string inputString = "test";
        var isValid = Bytes.CanParse(inputString);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Bytes(inputString));
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
        var value = $"hex:1a${invalidLetter}";
        var isValid = Bytes.CanParse(value);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Bytes(value));
    }

    [Fact]
    public void ValidHexDataShouldBeReadable()
    {
        var value = "hex:1a223e";

        var isValid = Bytes.CanParse(value);
        var bytes = new Bytes(value);


        Assert.True(isValid);
        Assert.Equal("1a223e", bytes.Value);
    }
}