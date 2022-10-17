namespace Biscuit.Parse.Language;

public class Bytes : IPrimordialData
{
    public string InputString { get; }
    public string Value { get; }

    public Bytes(string inputString)
    {
        InputString = inputString;
        Value = IsValid() ? InputString.Trim().Replace("hex:", "") : "";
    }
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(InputString) && InputString.StartsWith("hex:");
    }
}