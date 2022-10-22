using System;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class VariableTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void NullOrEmptyStringShouldNotBeValidVariable(string input)
    {
        var isValid = Variable.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Variable(input));
    }

    [Fact]
    public void VariableShouldStartWithDollar()
    {
        const string input = "test";
        var isValid = Variable.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Variable(input));
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
    public void VariableShouldNotContainForbiddenCharacters(char insertedChar)
    {
        var input = $"$aa{insertedChar}a";

        var isValid = Variable.CanParse(input);

        Assert.False(isValid);
        Assert.Throws<InvalidOperationException>(() => new Variable(input));
    }

    [Fact]
    public void VariableNameShouldBeVariableWithoutDollar()
    {
        const string input = "$test";

        var isValid = Variable.CanParse(input);
        var variable = new Variable(input);

        Assert.True(isValid);
        Assert.Equal("test", variable.VariableName);
    }
}