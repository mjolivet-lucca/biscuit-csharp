namespace Biscuit.Parse.Language;

public interface IValidateable
{
    string InputString { get; }
    bool IsValid();
}