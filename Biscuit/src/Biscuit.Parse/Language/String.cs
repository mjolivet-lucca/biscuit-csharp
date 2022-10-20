namespace Biscuit.Parse.Language;

public class String : IFactTermValue, ISetTermValue
{
    public string InputString { get; }

    public String(string inputString)
    {
        InputString = inputString;
    }
    public string Value => InputString;
    public static bool CanParse() => true;
}