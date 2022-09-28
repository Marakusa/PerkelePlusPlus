namespace PerkelePlusPlus;

public class Parser
{
    private readonly List<SyntaxTree> _syntaxTree = new();

    public Parser()
    {
        _syntaxTree.Clear();
    }
    
    // Valmista merkkijono nimeltä foo, jonka arvo on "Hei maailma".
    // string foo = "Hei maailma";
    
    public IEnumerable<SyntaxTree> Parse(List<Token> tokens)
    {
        SyntaxTree tree;
        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i].TokenType == TokenType.StatementTerminator)
            {
                tree = new SyntaxTree(tokens[i]);
                break;
            }

            if (tokens[i].TokenType == TokenType.Keyword)
            {
                if (tokens[i].Value.Equals("valmista", StringComparison.InvariantCultureIgnoreCase))
                {
                    tree = new SyntaxTree(tokens[i])
                    {
                        
                    };
                }
            }
        }
        _syntaxTree.Add(tree);
        return _syntaxTree;
    }
}
