namespace DynamicDependencyInjectionExample.Parser.Interfaces;

public interface IParser<T>
{
    Task<string> Parse(string text);
}
