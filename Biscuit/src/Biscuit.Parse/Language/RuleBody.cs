namespace Biscuit.Parse.Language;

public class RuleBody : IParseable
{
    public string InputString { get; }

    public RuleBody(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(RuleBody)} -> {inputString}");
        }
    }
    public static bool CanParse(string value)
    {
        throw new NotImplementedException();
    }
}