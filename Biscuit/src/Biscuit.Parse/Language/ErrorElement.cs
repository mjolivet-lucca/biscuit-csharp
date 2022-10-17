namespace Biscuit.Parse.Language;

public class ErrorElement : ILogicalElement
{
    public string InputString => "parsing error";
    public bool IsValid() => false;
}