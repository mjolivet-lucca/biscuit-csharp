using System.Globalization;

namespace Biscuit.Parse.Language;

public class Date : IPrimordialData
{
    public string InputString { get; }
    public DateTime Value { get; set; }

    public Date(string inputString)
    {
        InputString = inputString;
        Value = IsValid() && ParseDate(out var result) ? result : DateTime.MinValue;
    }
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(InputString) && ParseDate(out _);
    }

    private bool ParseDate(out DateTime result)
    {
        return ParseWithFormat(out result, "yyyy-MM-ddTHH:mm:ss")
            || ParseWithFormat(out result, "yyy-MM-ddTHH:mm:ss")
            || ParseWithFormat(out result, "yy-MM-ddTHH:mm:ss")
            || ParseWithFormat(out result, "y-MM-ddTHH:mm:ss")
            || ParseWithFormat(out result, "yyyy-MM-ddTHH:mm:ssZ")
            || ParseWithFormat(out result, "yyyy-MM-ddTHH:mm:sszzz");
    }

    private bool ParseWithFormat(out DateTime result, string format)
    {
        return DateTime.TryParseExact(InputString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
    }
}