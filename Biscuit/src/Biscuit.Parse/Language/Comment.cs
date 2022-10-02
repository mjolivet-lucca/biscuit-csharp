using System.Text.RegularExpressions;

namespace Biscuit.Parse.Language;

public class Comment : IBlockElement
{
    private readonly Regex _validCharacters = new ("^[a-zA-Z0-9_: \t()$\\[\\]]+$");
    public string InputString { get; }

    public Comment(string inputString)
    {
        InputString = inputString;
        Element = ParseInput();
    }

    private CommentText ParseInput()
        => !IsValid()
            ? new CommentText("")
            : new CommentText(InputString[3..].Trim());


    public bool IsValid()
    {
        return InputString.Length >= 6
               && InputString.StartsWith("//")
               && InputString.EndsWith('\n')
               && char.IsLetter(InputString[2])
               && _validCharacters.Match(InputString[3..].Trim()).Success;
    }

    public ILogicalElement Element { get; }
}