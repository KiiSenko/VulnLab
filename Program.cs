using Microsoft.EntityFrameworkCore;
using MyVulnerableApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi i servizi per i controller e le viste
builder.Services.AddControllersWithViews();

// Configura il DbContext per l'uso di SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Data/users.db"));

var app = builder.Build();

// Configura il database (assicurati che esista)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();  // Crea il database se non esiste

    // Aggiungi un utente admin se non esiste già
    if (!dbContext.Users.Any())
    {
        dbContext.Users.Add(new AppDbContext.User { Username = "admin", Password = "password" });
        dbContext.SaveChanges();
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();





