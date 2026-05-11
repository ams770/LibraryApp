using LibraryApp.Borrowing.Infrastructure;
using LibraryApp.Catalog.Infrastructure;
using LibraryApp.Members.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ── Services ────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// ── Modules ─────────────────────────────────────────────────
builder.Services.AddCatalogModule(builder.Configuration);
builder.Services.AddMemberModule(builder.Configuration);
builder.Services.AddBorrowingModule(builder.Configuration);

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