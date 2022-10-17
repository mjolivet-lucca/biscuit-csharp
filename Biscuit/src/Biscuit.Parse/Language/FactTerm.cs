namespace Biscuit.Parse.Language;

public class FactTerm : ITerm
{
    public string InputString { get; }
    public IPrimordialData Data { get; set; }

    public FactTerm(string inputString)
    {
        InputString = inputString;
    }
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(InputString);
    }
}