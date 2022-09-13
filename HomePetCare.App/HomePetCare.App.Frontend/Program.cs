// using HomePetCare.App.Persistencia;
// using HomePetCare.App.Dominio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// builder.Services.AddSingleton<IRepositorioMascota, RepositorioMascota>();

var app = builder.Build();

// IRepositorioMascota service = app.Services.GetRequiredService<IRepositorioMascota>();
// ILogger logger = app.Logger;
// IHostApplicationLifetime lifetime = app.Lifetime;
// IWebHostEnvironment env = app.Environment;

// lifetime.ApplicationStarted.Register(() =>
//     logger.LogInformation(
//         $"The application {env.ApplicationName} started" +
//         $" with injected {service}"));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
