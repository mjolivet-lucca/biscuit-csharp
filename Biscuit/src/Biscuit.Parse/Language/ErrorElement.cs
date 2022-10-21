namespace Biscuit.Parse.Language;

public class ErrorElement : ILogicalElement
{
    public string InputString => "parsing error";
    public static bool CanParse(string value) => false;
}