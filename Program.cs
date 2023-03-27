using Microsoft.OpenApi.Models;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        name: "minimalapi",
        info: new OpenApiInfo
        {
            Title = "Minimal API",
            Description = "Here , We Are learning to use Minimal API in out project.",
            Version = "V1"
        }
    );
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.SwaggerEndpoint("/swagger/minimalapi/swagger.json", "Minimal API V1");
});

app.MapGet("/", () => "Hello World!");

// Minimal API Usage
app.MapGet("/people", () => FakeDB.GetPeople());
app.MapGet("/people/{id}", (int id) => FakeDB.Get(id));
app.MapPut("/people", (Person person) => FakeDB.Update(person));
app.MapPost("/people", (Person person) => FakeDB.Add(person));
app.MapDelete("/people/{id}", (int id) => FakeDB.Delete(id));

app.Run();
