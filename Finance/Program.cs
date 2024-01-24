using Finance.db;
using Finance.dto;
using Finance.models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Database>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/user/register", async (User req, Database db) =>
{
    db.Users.Add(req);
    await db.SaveChangesAsync();
    return Results.Ok(req.id);
});

app.MapPost("/user/login", async (LoginDto req, Database db) =>
{
    User? result = Array.Find(
        db.Users.ToArray(), 
        element => element.login == req.login && element.password == req.password
    );

    return result is User 
        ? Results.Ok(new ClientLoginDto(result)) 
        : Results.BadRequest("Неверный логин или пароль");
});

app.MapPost("/wallet", async (Wallet req, Database db) =>
{
    db.Wallets.Add(req);
    await db.SaveChangesAsync();
    return Results.Created($"/wallet/{req.id}", req);
});

app.MapGet("/wallet/{id}", async (int id, Database db) =>
{
    return Array.Find(db.Wallets.ToArray(), element => element.user == id);
});

app.MapPost("/change", async (Change req, Database db) =>
{
    db.Changes.Add(req);
    await db.SaveChangesAsync();
    return Results.Created($"/change/{req.id}", req);
});

app.MapGet("/change/{id}", async (int id, Database db) =>
{
    return Array.Find(db.Changes.ToArray(), element => element.wallet == id);
});

app.MapPost("/purpose", async (Purpose req, Database db) =>
{
    db.Purposes.Add(req);
    await db.SaveChangesAsync();
    return Results.Created($"/purpose/{req.id}", req);
});

app.MapGet("/purpose/{id}", async (int id, Database db) =>
{
    return Array.FindAll(db.Purposes.ToArray(), element => element.user == id);
});

app.Run();
