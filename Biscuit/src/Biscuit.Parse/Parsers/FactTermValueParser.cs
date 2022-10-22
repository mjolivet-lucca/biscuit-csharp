using Biscuit.Parse.Language;
using Boolean = Biscuit.Parse.Language.Boolean;
using String = Biscuit.Parse.Language.String;

namespace Biscuit.Parse.Parsers;

public static class FactTermValueParser
{
    public static IFactTermValue Parse(string inputString)
        => inputString switch
        {
            { } v when Boolean.CanParse(v) => new Boolean(v),
            { } v when Number.CanParse(v) => new Number(v),
            { } v when Bytes.CanParse(v) => new Bytes(v),
            { } v when Date.CanParse(v) => new Date(v),
            { } v when Set.CanParse(v) => new Set(v),
            _ => new String(inputString)
        };
}