using Biscuit.Parse.Parsers;

namespace Biscuit.Parse.Language;

public class FactTerm : ITerm
{
    public string InputString { get; }
    public IFactTermValue Data { get; set; }

    public FactTerm(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(FactTerm)} -> {inputString}");
        }
        Data = FactTermValueParser.Parse(InputString);
    }
    public static bool CanParse(string value)
        => !string.IsNullOrWhiteSpace(value);
}