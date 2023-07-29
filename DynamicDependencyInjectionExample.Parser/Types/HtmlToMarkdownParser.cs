using DynamicDependencyInjectionExample.Parser.Interfaces;

namespace DynamicDependencyInjectionExample.Parser.Types;

public class HtmlToMarkdownParser : IParser<HtmlToMarkdownParser>
{
    public async Task<string> Parse(string text)
    {
        Console.WriteLine(nameof(HtmlToMarkdownParser));
        return await Task.FromResult(text);
    }
}