namespace Biscuit.Parse.Language;

public class BlockElement : IBlockElement
{
    public string InputString { get; }
    public ILogicalElement Element { get; }

    public BlockElement(string inputString)
    {
        InputString = inputString;
        Element = new LogicalElementFactory().PopulateElement(inputString);
    }

    public bool IsValid()
    {
        return InputString.Trim().EndsWith(";") && Element.IsValid();
    }

}