namespace Biscuit.Parse.Language;

public class BlockElement : IBlockElement
{
    public string InputString { get; }
    public ILogicalElement Element { get; }

    public BlockElement(string inputString)
    {
        InputString = inputString;
    }

    public bool IsValid()
    {
        return InputString.Trim().EndsWith(";");
    }

}