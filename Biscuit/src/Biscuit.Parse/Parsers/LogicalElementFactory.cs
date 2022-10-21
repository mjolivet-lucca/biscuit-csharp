namespace Biscuit.Parse.Language;

public class LogicalElementFactory
{
    public ILogicalElement PopulateElement(string inputString)
    {
        if (string.IsNullOrWhiteSpace(inputString))
        {
            return new ErrorElement();
        }

        return new Fact(inputString);
    }
}