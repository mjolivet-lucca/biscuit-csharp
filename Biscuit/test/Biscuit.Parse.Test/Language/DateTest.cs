using System;
using System.Globalization;
using Biscuit.Parse.Language;
using Xunit;

namespace Biscuit.Parse.Test.Language;

public class DateTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void DateShouldBeInvalidWhenNullOrEmpty(string inputData)
    {
        var isValid = Date.CanParse(inputData);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Date(inputData));
    }

    [Fact]
    public void NonDateFormatShouldBeInvalid()
    {
        const string exampleDate = "aze23";
        var isValid = Date.CanParse(exampleDate);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Date(exampleDate));
    }

    [Theory]
    [InlineData("20221203")]
    [InlineData("2022/12/03")]
    [InlineData("17/05/1982")]
    public void NonIso8601DateShouldNotBeValid(string exampleDate)
    {
        var isValid = Date.CanParse(exampleDate);

        Assert.False(isValid);

        Assert.Throws<InvalidOperationException>(() => new Date(exampleDate));
    }

    [Theory]
    [InlineData("2022-12-03T11:37:28")]
    [InlineData("522-12-03T11:37:28")]
    [InlineData("22-12-03T11:37:28")]
    [InlineData("2-12-03T11:37:28")]
    [InlineData("2022-12-03T11:37:28Z")]
    [InlineData("2022-12-03T11:37:28+05:00")]
    [InlineData("2022-12-03T11:37:28-05:00")]
    public void Iso8601DateShouldBeValidWith3Formats(string exampleDate)
    {
        var isValid = Date.CanParse(exampleDate);
        var date = new Date(exampleDate);

        Assert.True(isValid);
        Assert.NotEqual(DateTime.MinValue, date.Value);
    }
}