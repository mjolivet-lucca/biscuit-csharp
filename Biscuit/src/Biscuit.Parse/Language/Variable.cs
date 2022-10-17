namespace Biscuit.Parse.Language;

public class Variable : ITerm
{
    public string InputString { get; }

    public Variable(string inputString)
    {
        InputString = inputString;
    }
    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}