using Biscuit.Parse.Parsers;

namespace Biscuit.Parse.Language;

public class Set : IFactTermValue
{
    public string InputString { get; }
    //TODO : Est ce qu'on veut autoriser les sets dans les sets et uniquement en première position ?
    // sous entendu par <set> ::= "[" <sp>? ( <fact_term> ( <sp>? "," <sp>? <set_term>)* <sp>? )? "]"
    public IReadOnlyCollection<ISetTermValue> Value { get; set; }


    public Set(string inputString)
    {
        InputString = inputString;
        if (!CanParse(InputString))
        {
            throw new InvalidOperationException($"{nameof(Set)} -> {inputString}");
        }
        Value = ParseTerms();
    }

    public static bool CanParse(string value)
        => !string.IsNullOrWhiteSpace(value)
            && value.StartsWith('[')
            && value.EndsWith(']');


    private IReadOnlyCollection<ISetTermValue> ParseTerms()
    {
        var content = InputString[1..^1]
            .Split(',')
            .Select(c => c.Trim());
        return content.Select(SetTermParser.Parse).ToList();
    }
}