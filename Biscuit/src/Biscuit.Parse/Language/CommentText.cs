namespace Biscuit.Parse.Language;

public class CommentText : ILogicalElement
{
    public CommentText(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(CommentText)} -> {inputString}");
        }
    }
    public string InputString { get; }
    public static bool CanParse(string value) => !string.IsNullOrWhiteSpace(value);
}