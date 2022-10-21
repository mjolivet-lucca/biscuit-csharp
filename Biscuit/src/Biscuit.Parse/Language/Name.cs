namespace Biscuit.Parse.Language;

public class Name : IParseable
{
    public string InputString { get; }

    public Name(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Name)} -> {inputString}");
        }
    }
    public static bool CanParse(string value)
    {
        var name = value?.Trim();
        return !string.IsNullOrWhiteSpace(name)
               && name.Length >= 2
               && char.IsLetter(name[0])
               && name.All(c => char.IsLetter(c) || char.IsNumber(c) || c is ':' or '_');
    }
}