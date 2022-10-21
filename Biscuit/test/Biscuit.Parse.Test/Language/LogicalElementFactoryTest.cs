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

        Assert.IsType<ErrorElement>(element);
    }

    [Fact]
    public void ShouldBeAbleToRetrieveFact_WhenValidFactIsGiven()
    {
        var factory = new LogicalElementFactory();

        var element = factory.PopulateElement("az");

        Assert.IsType<Fact>(element);

        var isValid = Fact.CanParse("az");

        Assert.True(isValid);
        Assert.NotNull(element);
    }

}