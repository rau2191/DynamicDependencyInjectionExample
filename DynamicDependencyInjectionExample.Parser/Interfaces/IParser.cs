namespace DynamicDependencyInjectionExample.Parser.Interfaces;

public interface IParser<T> where T : new()
{
    Task<string> Parse(string text);
}
