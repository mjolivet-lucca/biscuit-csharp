namespace Biscuit.Parse.Language;

public class Block
{
    public IReadOnlyCollection<IBlockElement> Type { get; set; }

    public Block(IReadOnlyCollection<IBlockElement> type)
    {
        Type = type;
    }
}