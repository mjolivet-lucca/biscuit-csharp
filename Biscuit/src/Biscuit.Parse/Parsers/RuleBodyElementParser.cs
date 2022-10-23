using Biscuit.Parse.Language;

namespace Biscuit.Parse.Parsers;

public static class RuleBodyElementParser
{
    public static IRuleBodyElement Parse(string inputString)
        => inputString switch
        {
            { } v when LogicalPredicate.CanParse(v) => new LogicalPredicate(v),
            { } v when Expression.CanParse(v) => new Expression(v),
            _ => new ErrorElement()
        };

    public static bool CanParse(string value)
        => LogicalPredicate.CanParse(value) || Expression.CanParse(value);
}