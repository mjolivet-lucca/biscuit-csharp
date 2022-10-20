using System.Globalization;

namespace Biscuit.Parse.Language;

public class Date : IFactTermValue, ISetTermValue
{
    public string InputString { get; }
    public DateTime Value { get; set; }

    public Date(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Date)} -> {inputString}");
        }
        Value = ParseDate(InputString, out var result) ? result : DateTime.MinValue;
    }
    public static bool CanParse(string value)
        => !string.IsNullOrWhiteSpace(value) && ParseDate(value, out _);

    private static bool ParseDate(string value, out DateTime result)
        => ParseWithFormat(value, out result, "yyyy-MM-ddTHH:mm:ss")
            || ParseWithFormat(value, out result, "yyy-MM-ddTHH:mm:ss")
            || ParseWithFormat(value, out result, "yy-MM-ddTHH:mm:ss")
            || ParseWithFormat(value, out result, "y-MM-ddTHH:mm:ss")
            || ParseWithFormat(value, out result, "yyyy-MM-ddTHH:mm:ssZ")
            || ParseWithFormat(value, out result, "yyyy-MM-ddTHH:mm:sszzz");

    private static bool ParseWithFormat(string value, out DateTime result, string format)
        => DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
}