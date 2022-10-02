namespace Biscuit.Parse.Language;

public class CommentText : ILogicalElement
{
    public CommentText(string inputString)
    {
        InputString = inputString;
    }
    public string InputString { get; }
    public bool IsValid() => !string.IsNullOrWhiteSpace(InputString);
}