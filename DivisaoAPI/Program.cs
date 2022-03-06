using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/divisao",
(
    [FromQuery] double numerador,
    [FromQuery] double denominador
) => {
    if (denominador == 0) return Results.BadRequest(new { mensagem = "Denominador não pode ser zero." });

    var resultado = numerador / denominador;

    return Results.Ok(new {
        numerdor = numerador,
        denominador = denominador,
        resultado = resultado
    });
});

app.Run();
