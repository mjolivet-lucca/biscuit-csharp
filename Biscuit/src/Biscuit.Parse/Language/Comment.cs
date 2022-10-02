using System.Text.RegularExpressions;

namespace Biscuit.Parse.Language;

public class Comment : IBlockElement
{
    private Regex validCharacters = new ("^[a-zA-Z0-9_: \t()$\\[\\]]+$");
    public string InputString { get; }

    public Comment(string inputString)
    {
        InputString = inputString;
    }


    public bool IsValid()
    {
        return InputString.Length >= 6
               && InputString.StartsWith("//")
               && InputString.EndsWith('\n')
               && char.IsLetter(InputString[2])
               && validCharacters.Match(InputString[3..].Trim()).Success;
    }
}