namespace Biscuit.Parse.Language;

public class Fact : ILogicalElement
{
    public string InputString { get; }

    public Fact(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Fact)} -> {inputString}");
        }
    }
    public static bool CanParse(string value)
    {
        return true;
    }
}