namespace Biscuit.Parse.Language;

public class Rule : ILogicalElement
{
    public string InputString { get; }

    public Rule(string inputString)
    {
        InputString = inputString;
    }
    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}