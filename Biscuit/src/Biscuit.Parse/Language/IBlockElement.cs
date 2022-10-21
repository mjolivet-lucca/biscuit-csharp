namespace Biscuit.Parse.Language;

public interface IBlockElement : IParseable
{
    ILogicalElement Element { get; }
}