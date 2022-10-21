namespace Biscuit.Parse.Language;

public class LogicalPredicate : IParseable
{
    public string InputString { get; }
    public Name Name { get; }
    public ITerm Term { get; }
    public LogicalPredicate(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(LogicalPredicate)} -> {inputString}");
        }
    }
    public static bool CanParse(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}