using Biscuit.Parse.Language;

namespace Biscuit.Parse.Parsers;

public static class TermParser
{
    public static ITerm Parse(string inputString)
        => inputString switch
        {
            { } v when FactTerm.CanParse(v) => new FactTerm(v),
            { } v when Variable.CanParse(v) => new Variable(v),
            _ => new ErrorElement()
        };

    public static bool CanParse(string input)
        => FactTerm.CanParse(input) || Variable.CanParse(input);
}