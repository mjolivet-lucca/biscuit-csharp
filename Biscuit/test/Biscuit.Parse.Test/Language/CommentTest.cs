using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class CommentTest
{
    [Fact]
    public void EmptyString_IsNotValidComment()
    {
        var inputString = string.Empty;
        var comment = new Comment(inputString);

        var isValid = comment.IsValid();

        Assert.False(isValid);
    }

    [Fact]
    public void Comment_ShouldStartWithDoubleSlash_AndEndWithLineReturn_ContainAtLeastOneLetter_FollowedByValidCharacter()
    {
        var inputString = $"//Aa{System.Environment.NewLine}";
        var comment = new Comment(inputString);

        var isValid = comment.IsValid();

        Assert.True(isValid);
    }

    [Theory]
    [InlineData("µ")]
    [InlineData("*")]
    public void InvalidCharacters_ShouldNotBeAuthorized_InComments(string character)
    {
        var inputString = $"//{character}{System.Environment.NewLine}";
        var comment = new Comment(inputString);

        var isValid = comment.IsValid();

        Assert.False(isValid);
    }

    [Fact]
    public void Comment_ShouldBeInvalidIfNotStartingWithDoubleSlash()
    {
        var inputString = $"Aa{System.Environment.NewLine}";
        var comment = new Comment(inputString);

        var isValid = comment.IsValid();

        Assert.False(isValid);
    }

    [Fact]
    public void Comment_ShouldBeInvalidIfNotEndingWithLineReturn()
    {
        var inputString = "//Aa";
        var comment = new Comment(inputString);

        var isValid = comment.IsValid();

        Assert.False(isValid);
    }

    [Fact]
    public void Comment_ShouldBeInvalidIfCharacterFollowingSlashes_AreNotLetters()
    {
        var inputString = $"//1a{System.Environment.NewLine}";
        var comment = new Comment(inputString);

        var isValid = comment.IsValid();

        Assert.False(isValid);
    }

    [Fact]
    public void Comment_ShouldBeInvalidIfOnlyOneCharacters_AppartFromSlashesAndLineReturn()
    {
        var inputString = $"//a{System.Environment.NewLine}";
        var comment = new Comment(inputString);

        var isValid = comment.IsValid();

        Assert.False(isValid);
    }

    [Fact]
    public void Comment_ShouldBeValidForAnyAuthorizedCharacter()
    {
        var inputString = $"//abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_:  ()$[]{System.Environment.NewLine}";
        var comment = new Comment(inputString);

        var isValid = comment.IsValid();

        Assert.True(isValid);
    }

    [Fact]
    public void Comment_ShouldNotBeValidIfAnyUnauthorizedCharacterIsInserted()
    {
        var inputString = $"//abcdefghijklmnopqrstuvwxyzABCD*$£EFGHIJKLMNOPQRSTUVWXYZ0123456789_:  ()$[]{System.Environment.NewLine}";
        var comment = new Comment(inputString);

        var isValid = comment.IsValid();

        Assert.False(isValid);
    }
}