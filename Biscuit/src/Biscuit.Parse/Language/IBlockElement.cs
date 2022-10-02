namespace Biscuit.Parse.Language;

public interface IBlockElement : IValidateable
{
    ILogicalElement Element { get; }
}