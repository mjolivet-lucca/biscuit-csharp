namespace Biscuit.Parse.Language;

public class Name : IValidateable
{
    public string InputString { get; }

    public Name(string inputString)
    {
        InputString = inputString;
    }
    public bool IsValid()
    {
        var name = InputString?.Trim();
        return !string.IsNullOrWhiteSpace(name)
               && name.Length >= 2
               && char.IsLetter(name[0])
               && name.All(c => char.IsLetter(c) || char.IsNumber(c) || c is ':' or '_');
    }
}