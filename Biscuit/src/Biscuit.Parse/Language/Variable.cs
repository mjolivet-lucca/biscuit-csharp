namespace Biscuit.Parse.Language;

public class Variable : ITerm
{
    public string InputString { get; }

    public Variable(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Variable)} -> {inputString}");
        }
    }
    public static bool CanParse(string value)
    {
        throw new NotImplementedException();
    }
}