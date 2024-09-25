var builder = WebApplication.CreateBuilder(args);

// Ajoutez des services au conteneur.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurez le pipeline des requêtes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // La valeur HSTS par défaut est de 30 jours. Vous voudrez peut-être la changer pour des scénarios de production.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Définir les routes
app.MapControllerRoute(
    name: "animal",
    pattern: "Animal/{action=Index}/{id?}",
    defaults: new { controller = "Animal" } // On peut omettre 'action=Index' ici
);

app.MapControllerRoute(
    name: "Default",
    pattern: "Login/{action=Index}/{id?}",
    defaults: new { controller = "Login", action = "Index" }
);

app.MapControllerRoute(
    name: "accueil",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
