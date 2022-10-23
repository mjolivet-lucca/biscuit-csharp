using Biscuit.Parse.Parsers;

namespace Biscuit.Parse.Language;

public class RuleBody : IParseable
{
    public string InputString { get; }
    public IReadOnlyCollection<IRuleBodyElement> RuleBodyElements { get; set; }

    public RuleBody(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(RuleBody)} -> {inputString}");
        }

        RuleBodyElements = inputString
            .Split(',')
            .Select(s => RuleBodyElementParser.Parse(s.Trim()))
            .ToList();
    }
    public static bool CanParse(string value)
    {
        return !string.IsNullOrWhiteSpace(value)
            && value.Split(',').All(v => RuleBodyElementParser.CanParse(v.Trim()));
    }
}