namespace Biscuit.Parse.Language;

public class Check : ILogicalElement
{
    public string InputString { get; }

    public Check(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Check)} -> {inputString}");
        }
    }
    public static bool CanParse(string value)
    {
        throw new NotImplementedException();
    }
}