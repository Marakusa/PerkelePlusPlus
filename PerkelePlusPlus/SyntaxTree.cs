namespace PerkelePlusPlus;

public class SyntaxTree
{
    public SyntaxTree(Token token)
    {
        Token = token;
        ChildNodes = new List<SyntaxTree>();
    }
    
    public Token Token { get; }
    public List<SyntaxTree> ChildNodes { get; }
}
