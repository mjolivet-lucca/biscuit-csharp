namespace Biscuit.Parse.Language;

public class BlockElement : IBlockElement
{
    public string InputString { get; }
    public ILogicalElement Element { get; }

    public BlockElement(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(BlockElement)} -> {inputString}");
        }
        Element = new LogicalElementFactory().PopulateElement(inputString);
    }

    public static bool CanParse(string value)
        => !string.IsNullOrWhiteSpace(value) && value.Trim().EndsWith(";") ;//&& Element.IsValid(); // TODO: revoir


}