namespace Biscuit.Parse.Language;

public class Rule : ILogicalElement
{
    public string InputString { get; }
    public LogicalPredicate Predicate { get; }
    public RuleBody RuleBody { get; }

    public Rule(string inputString)
    {
        InputString = inputString;

    }
    public bool IsValid()
    {
        return InputString.Contains("<-") && Predicate.IsValid() && RuleBody.IsValid();
    }
}