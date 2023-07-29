using DynamicDependencyInjectionExample.Parser.Interfaces;

namespace DynamicDependencyInjectionExample.Parser.Types;

public class MarkdownToHtmlParser : IParser<MarkdownToHtmlParser>
{
    public async Task<string> Parse(string text)
    {
        Console.WriteLine(nameof(MarkdownToHtmlParser));
        return await Task.FromResult(text);
    }
}