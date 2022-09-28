namespace PerkelePlusPlus;

public static class Program
{
    private static void Main(string[] args)
    {
        Lexer lexer = new();
        var tokens = lexer.Tokenize(File.ReadAllText("Code/HelloWorld.ppp"));
        
        foreach (Token token in tokens)
        {
            Console.WriteLine(token.Value);
            Console.WriteLine("\t" + token.TokenType);
        }

        Parser parser = new();
        var syntaxTree = parser.Parse(tokens);
    }
}