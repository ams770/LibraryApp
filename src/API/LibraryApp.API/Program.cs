using LibraryApp.Catalog.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ── Services ────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddOpenApi(); // ← this was missing

// ── Modules ─────────────────────────────────────────────────
builder.Services.AddCatalogModule(builder.Configuration);

// ── Pipeline ─────────────────────────────────────────────────
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();