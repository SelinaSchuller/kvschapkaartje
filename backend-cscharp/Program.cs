var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("SchapwijzerFrontend", policy =>
    {
        policy.WithOrigins("https://selinaschuller.github.io")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors("SchapwijzerFrontend");

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

