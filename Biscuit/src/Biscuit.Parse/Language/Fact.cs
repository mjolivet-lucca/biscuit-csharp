namespace Biscuit.Parse.Language;

public class Fact : ILogicalElement
{
    public string InputString { get; }

    public Fact(string inputString)
    {
        InputString = inputString;
    }
    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}