using DynamicDependencyInjectionExample.Parser.Extensions;
using DynamicDependencyInjectionExample.Parser.Interfaces;
using DynamicDependencyInjectionExample.Parser.Types;
using DynamicDependencyInjectionExample.Test.DTOs;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddParsers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/parse-markdown-to-html", async (
    IParser<MarkdownToHtmlParser> parser,
    [FromBody] MarkdownToHtmlParsingRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Text))
    {
        return Results.BadRequest($"{nameof(request.Text)} cannot be empty");
    }

    string parsedText = await parser.Parse(request.Text);

    return Results.Ok(parsedText);
})
.WithName("ParseMarkdownToHtml");

app.MapPost("/parse-html-to-markdown", async (
    IParser<HtmlToMarkdownParser> parser,
    [FromBody] HtmlToMarkdownParsingRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Text))
    {
        return Results.BadRequest($"{nameof(request.Text)} cannot be empty");
    }

    string parsedText = await parser.Parse(request.Text);

    return Results.Ok(parsedText);
})
.WithName("ParseHtmlToMarkdown");

app.Run();
