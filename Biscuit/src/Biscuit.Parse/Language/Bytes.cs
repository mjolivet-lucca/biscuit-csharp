namespace Biscuit.Parse.Language;

public class Bytes : IFactTermValue, ISetTermValue
{
    public string InputString { get; }
    public string Value { get; }

    public Bytes(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Bytes)} -> {inputString}");
        }
        Value = InputString.Trim().Replace("hex:", "");
    }
    public static bool CanParse(string value)
        => !string.IsNullOrWhiteSpace(value)
           && value.StartsWith("hex:")
           && value[4..].All(c => char.IsNumber(c) || (char.IsLetter(c) && new[]{'a', 'b', 'c', 'd', 'e', 'f'}.Contains(c)));
}