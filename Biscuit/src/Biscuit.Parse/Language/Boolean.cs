namespace Biscuit.Parse.Language;

public class Boolean : IFactTermValue, ISetTermValue
{
    public string InputString { get; }
    public bool Value { get; set; }

    public Boolean(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(System.Boolean)} -> {inputString}");
        }
        Value = bool.Parse(InputString);
    }
    public static bool CanParse(string value)
    {
        return !string.IsNullOrWhiteSpace(value)
               && (
                   value.Equals("true")
                   || value.Equals("false")
                   );
    }
}