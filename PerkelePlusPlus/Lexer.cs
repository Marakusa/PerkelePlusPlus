using System.Text.RegularExpressions;

namespace PerkelePlusPlus;

public class Lexer
{
    private string _word = "";
    private List<Token> _tokens = new();

    public List<Token> Tokenize(string code)
    {
        Regex wordRegex = new(@"([A-Za-zÅåÄäÖö])", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Regex endStatementRegex = new(@"([.])", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Regex whitespaceRegex = new(@"([\s,])", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Regex stringRegex = new("([\"])", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Regex escapeRegex = new(@"([\\])", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        _word = "";
        _tokens.Clear();
        
        for (int i = 0; i < code.Length; i++)
        {
            if (whitespaceRegex.IsMatch(code[i].ToString()))
            {
                EndWord(TokenType.Keyword);
                continue;
            }
            
            if (endStatementRegex.IsMatch(code[i].ToString()))
            {
                EndWord(TokenType.Keyword);
                _word += code[i].ToString();
                EndWord(TokenType.StatementTerminator);
                continue;
            }

            if (stringRegex.IsMatch(code[i].ToString()))
            {
                i++;
                while (i < code.Length && !stringRegex.IsMatch(code[i].ToString()))
                {
                    if (escapeRegex.IsMatch(code[i].ToString()))
                    {
                        i++;
                        if (i >= code.Length)
                            throw new IndexOutOfRangeException("Escape character should have a following character");
                    }

                    _word += code[i].ToString();
                    i++;
                }
                EndWord(TokenType.StringLiteral);
                continue;
            }

            if (wordRegex.IsMatch(code[i].ToString()))
            {
                _word += code[i].ToString();
                continue;
            }
            
            throw new Exception($"Invalid character '{code[i].ToString()}'");
        }

        return _tokens;
    }

    private void EndWord(TokenType type)
    {
        if (_word == "")
            return;

        _tokens.Add(new Token(_word, type));
        _word = "";
    }
}
