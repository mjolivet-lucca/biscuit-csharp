namespace Biscuit.Parse.Language;

public class Rule : ILogicalElement
{
    public string InputString { get; }
    public LogicalPredicate Predicate { get; }
    public RuleBody RuleBody { get; }

    public Rule(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Rule)} -> {inputString}");
        }
        // TODO : split and parse

    }
    public static bool CanParse(string value)
    {
        return value.Contains("<-"); //&& Predicate.IsValid() && RuleBody.IsValid();
    }
}