var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/hello-word", () => {
    return Results.Ok(new {
        mensagem = "Hello World!"
    });
});

app.Run();
