namespace Biscuit.Parse.Language;

public class Variable : ITerm
{
    public string InputString { get; }
    public string VariableName { get; set; }

    public Variable(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Variable)} -> {inputString}");
        }

        VariableName = inputString[1..];
    }
    public static bool CanParse(string value)
    {
        return !string.IsNullOrWhiteSpace(value)
            && value.StartsWith('$')
            && value[1..].All(c => char.IsLetter(c) || char.IsNumber(c) || c is ':' or '_');
    }
}