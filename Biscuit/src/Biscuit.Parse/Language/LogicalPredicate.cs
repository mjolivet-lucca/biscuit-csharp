using Biscuit.Parse.Parsers;

namespace Biscuit.Parse.Language;

public class LogicalPredicate : IParseable, IRuleBodyElement
{
    public string InputString { get; }
    public Name Name { get; }
    public IReadOnlyCollection<ITerm> Terms { get; }
    public LogicalPredicate(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(LogicalPredicate)} -> {inputString}");
        }
        var firstParenthesisPosition = inputString.IndexOf('(');
        Name = new Name(inputString[..firstParenthesisPosition].Trim());
        Terms = inputString[(firstParenthesisPosition + 1)..^1]
            .Split(',')
            .Select(t => TermParser.Parse(t.Trim()))
            .ToList();
    }

    public static bool CanParse(string value)
    {
        var firstParenthesisPosition = value?.IndexOf('(') ?? -1;
        return !string.IsNullOrWhiteSpace(value)
               && value.Contains('(')
               && value.EndsWith(')')
               && Name.CanParse(value[..firstParenthesisPosition].Trim())
               && value[(firstParenthesisPosition+1)..^1]
                   .Split(',')
                   .All(t => TermParser.CanParse(t.Trim()));
    }
}