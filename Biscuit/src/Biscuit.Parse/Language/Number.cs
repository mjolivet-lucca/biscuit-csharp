namespace Biscuit.Parse.Language;

public class Number : IFactTermValue, ISetTermValue
{
    public string InputString { get; }
    public int Value { get; }

    public Number(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Date)} -> {inputString}");
        }
        Value = int.Parse(InputString);
    }
    public static bool CanParse(string value)
        => !string.IsNullOrWhiteSpace(value) && int.TryParse(value, out _);
}