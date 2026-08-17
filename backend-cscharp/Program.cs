var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/calculate/{code}", (string code) =>
{
    try
    {
        var loc = LocationCalculator.Calculate(code);
        return Results.Ok(new { meter = loc.Meter, plank = loc.Plank, positie = loc.Positie, breedte = loc.Breedte });
    }
    catch (ArgumentException)
    {
        return Results.BadRequest();
    }
});

app.Run();

