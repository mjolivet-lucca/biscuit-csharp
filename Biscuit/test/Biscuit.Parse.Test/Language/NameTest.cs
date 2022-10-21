using System;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class NameTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void EmptyNameIsNotValid(string input)
    {
        var isValid = Name.CanParse(input);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Name(input));
    }

    [Fact]
    public void NameShouldStartWithALetter()
    {
        var input = "1A";

        var isValid = Name.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Name(input));
    }

    [Theory]
    [InlineData("A")]
    [InlineData(" A")]
    [InlineData("A ")]
    [InlineData(" A ")]
    public void NameShouldBeAtLeastTwoCharactersLongExceptSpaces(string inputString)
    {
        var isValid = Name.CanParse(inputString);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Name(inputString));
    }

    [Theory]
    [InlineData('!')]
    [InlineData('§')]
    [InlineData('/')]
    [InlineData('.')]
    [InlineData(';')]
    [InlineData('?')]
    [InlineData(',')]
    [InlineData('=')]
    [InlineData('+')]
    [InlineData('}')]
    [InlineData('°')]
    [InlineData(')')]
    [InlineData(']')]
    [InlineData('[')]
    [InlineData('(')]
    [InlineData('#')]
    [InlineData('-')]
    [InlineData('&')]
    [InlineData('~')]
    [InlineData('|')]
    public void NameShouldNotContainForbiddenCharacters(char insertedChar)
    {
        var input = $"aa{insertedChar}a";

        var isValid = Name.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Name(input));
    }

    [Fact]
    public void NameShouldBeValidWhenAtLeast2CharactersAndAllValidCharacters()
    {
        const string input = "aa:_23Z";

        var isValid = Name.CanParse(input);
        var name = new Name(input);

        Assert.True(isValid);
        Assert.NotNull(name);
    }
}