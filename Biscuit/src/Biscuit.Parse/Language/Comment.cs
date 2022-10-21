using System.Text.RegularExpressions;

namespace Biscuit.Parse.Language;

public class Comment : IBlockElement
{
    private static readonly Regex ValidCharacters = new ("^[a-zA-Z0-9_: \t()$\\[\\]]+$");
    public string InputString { get; }

    public Comment(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Comment)} -> {inputString}");
        }
        Element = new CommentText(InputString[3..].Trim());
    }


    public static bool CanParse(string value)
        => value.Length >= 6
               && value.StartsWith("//")
               && value.EndsWith('\n')
               && char.IsLetter(value[2])
               && ValidCharacters.Match(value[3..].Trim()).Success;


    public ILogicalElement Element { get; }
}