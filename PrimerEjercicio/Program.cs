using PrimerEjercicio.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Razor Pages (sin cambios raros)
builder.Services.AddRazorPages();

// EF Core + MySQL (Pomelo)
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LibraryContext>(opt =>
    opt.UseSqlite(cs));

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapGet("/", ctx =>
{
    ctx.Response.Redirect("/Libros");
    return Task.CompletedTask;
});

app.MapRazorPages();

// Crear BD y seed (igual que antes)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();

    // Si esto antes funcionaba, dejalo igual
    db.Database.EnsureCreated();

    await DbInitializer.SeedAsync(db);
}

app.Run();

