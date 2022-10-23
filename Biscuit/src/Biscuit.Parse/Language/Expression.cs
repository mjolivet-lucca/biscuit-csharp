namespace Biscuit.Parse.Language;

public class Expression : IParseable, IRuleBodyElement
{
    public string InputString { get; }

    public Expression(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Expression)} -> {inputString}");
        }
    }

    public static bool CanParse(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}