namespace Biscuit.Parse.Language;

public class Number : IPrimordialData
{
    public string InputString { get; }
    public int Value { get; }

    public Number(string inputString)
    {
        InputString = inputString;
        Value = IsValid() ? int.Parse(InputString) : 0;
    }
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(InputString) && int.TryParse(InputString, out _);
    }
}