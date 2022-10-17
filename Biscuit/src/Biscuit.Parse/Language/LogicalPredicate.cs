namespace Biscuit.Parse.Language;

public class LogicalPredicate : IValidateable
{
    public string InputString { get; }
    public Name Name { get; }
    public ITerm Term { get; }
    public LogicalPredicate(string inputString)
    {
        InputString = inputString;
    }
    public bool IsValid()
    {
        return false;
    }
}