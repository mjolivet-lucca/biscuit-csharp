namespace Biscuit.Parse.Language;

public class Boolean : IPrimordialData
{
    public string InputString { get; }
    public bool Value { get; set; }

    public Boolean(string inputString)
    {
        InputString = inputString;
        Value = IsValid() && bool.Parse(InputString);
    }
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(InputString)
               && (
                   InputString.Equals("true")
                   || InputString.Equals("false")
                   );
    }
}