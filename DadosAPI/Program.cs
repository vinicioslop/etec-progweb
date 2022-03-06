using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/dado",
(
    [FromQuery] string dado
) =>
{
    Random rnd = new Random();

    var valores = dado.Split('d');

    var iteracoes = Convert.ToInt32(valores[0]);
    var faces = Convert.ToInt32(valores[1]);

    if (iteracoes <= 0)
        return Results.BadRequest(new { mensagem = "O número de iterações precisa ser maior que 0." });

    int[] rolagens = new int[iteracoes];

    for (int i = 0; i < iteracoes; i++)
    {
        rolagens[i] = rnd.Next(1, faces + 1);
    }

    return Results.Ok(
        new
        {
            dado = dado,
            rolagens = rolagens
        }
    );
});

app.Run();
