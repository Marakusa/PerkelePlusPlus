namespace PerkelePlusPlus;

public class Token
{
    public Token(string value, TokenType tokenType)
    {
        Value = value;
        TokenType = tokenType;
    }

    public string Value { get; }

    public TokenType TokenType { get; }
}

public enum TokenType
{
    Keyword,
    StringLiteral,
    IntegerLiteral,
    FloatLiteral,
    DoubleLiteral,
    BooleanLiteral,
    Null,
    StatementTerminator
}
