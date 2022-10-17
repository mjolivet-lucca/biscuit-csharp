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
        var name = new Name(input);

        var isValid = name.IsValid();

        Assert.False(isValid);
    }

    [Fact]
    public void NameShouldStartWithALetter()
    {
        var name = new Name("1A");

        var isValid = name.IsValid();

        Assert.False(isValid);
    }

    [Theory]
    [InlineData("A")]
    [InlineData(" A")]
    [InlineData("A ")]
    [InlineData(" A ")]
    public void NameShouldBeAtLeastTwoCharactersLongExceptSpaces(string inputString)
    {
        var name = new Name(inputString);

        var isValid = name.IsValid();

        Assert.False(isValid);
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
        var name = new Name($"aa{insertedChar}a");

        var isValid = name.IsValid();

        Assert.False(isValid);
    }

    [Fact]
    public void NameShouldBeValidWhenAtLeast2CharactersAndAllValidCharacters()
    {
        var name = new Name("aa:_23Z");

        var isValid = name.IsValid();

        Assert.True(isValid);
    }
}