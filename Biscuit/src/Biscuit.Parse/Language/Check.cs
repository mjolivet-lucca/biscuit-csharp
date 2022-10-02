namespace Biscuit.Parse.Language;

public class Check : ILogicalElement
{
    public string InputString { get; }

    public Check(string inputString)
    {
        InputString = inputString;
    }
    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}