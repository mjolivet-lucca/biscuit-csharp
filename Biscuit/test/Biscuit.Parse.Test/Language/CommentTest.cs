using System;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class CommentTest
{
    [Fact]
    public void EmptyString_IsNotValidComment()
    {
        var input = string.Empty;

        var isValid = Comment.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Comment(input));
    }

    [Fact]
    public void Comment_ShouldStartWithDoubleSlash_AndEndWithLineReturn_ContainAtLeastOneLetter_FollowedByValidCharacter()
    {
        var inputString = $"//Aa{Environment.NewLine}";

        var isValid = Comment.CanParse(inputString);
        var comment = new Comment(inputString);

        Assert.True(isValid);
        Assert.NotNull(comment);
    }

    [Theory]
    [InlineData("µ")]
    [InlineData("*")]
    public void InvalidCharacters_ShouldNotBeAuthorized_InComments(string character)
    {
        var input = $"//{character}{Environment.NewLine}";

        var isValid = Comment.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Comment(input));
    }

    [Fact]
    public void Comment_ShouldBeInvalidIfNotStartingWithDoubleSlash()
    {
        var input = $"Aa{Environment.NewLine}";

        var isValid = Comment.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Comment(input));
    }

    [Fact]
    public void Comment_ShouldBeInvalidIfNotEndingWithLineReturn()
    {
        const string inputString = "//Aa";

        var isValid = Comment.CanParse(inputString);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Comment(inputString));
    }

    [Fact]
    public void Comment_ShouldBeInvalidIfCharacterFollowingSlashes_AreNotLetters()
    {
        var input = $"//1a{Environment.NewLine}";

        var isValid = Comment.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Comment(input));
    }

    [Fact]
    public void Comment_ShouldBeInvalidIfOnlyOneCharacters_AppartFromSlashesAndLineReturn()
    {
        var input = $"//a{Environment.NewLine}";

        var isValid = Comment.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Comment(input));
    }

    [Fact]
    public void Comment_ShouldBeValidForAnyAuthorizedCharacter()
    {
        var input = $"//abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_:  ()$[]{Environment.NewLine}";

        var isValid = Comment.CanParse(input);
        var comment = new Comment(input);

        Assert.True(isValid);
        Assert.NotNull(comment);
    }

    [Fact]
    public void Comment_ShouldNotBeValidIfAnyUnauthorizedCharacterIsInserted()
    {
        var input = $"//abcdefghijklmnopqrstuvwxyzABCD*$£EFGHIJKLMNOPQRSTUVWXYZ0123456789_:  ()$[]{Environment.NewLine}";

        var isValid = Comment.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Comment(input));
    }
}