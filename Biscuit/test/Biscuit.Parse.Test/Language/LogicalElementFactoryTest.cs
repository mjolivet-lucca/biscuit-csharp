using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class LogicalElementFactoryTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ShouldBeAbleToRetrieveErrorLogicalElement_WhenGivenNullOrEmptyString(string input)
    {
        var factory = new LogicalElementFactory();

        var element = factory.PopulateElement(input);
        var isValid = element.IsValid();

        Assert.False(isValid);
        Assert.IsType<ErrorElement>(element);
    }

    [Fact]
    public void ShouldBeAbleToRetrieveFact_WhenValidFactIsGiven()
    {
        var factory = new LogicalElementFactory();

        var element = factory.PopulateElement("az");
        var isValid = element.IsValid();

        Assert.True(isValid);
        Assert.IsType<Fact>(element);
    }
}