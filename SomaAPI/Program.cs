using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/soma",
(
    [FromQuery] int a,
    [FromQuery] int b
) => {
    int soma = a + b;

    return Results.Ok(new {
        a = a,
        b = b,
        soma = soma
    });
});

app.Run();
