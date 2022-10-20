using Biscuit.Parse.Parsers;

namespace Biscuit.Parse.Language;

public class FactTerm : ITerm
{
    public string InputString { get; }
    public IFactTermValue Data { get; set; }

    public FactTerm(string inputString)
    {
        InputString = inputString;
        Data = FactTermParser.Parse(InputString);
    }
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(InputString);
    }
}