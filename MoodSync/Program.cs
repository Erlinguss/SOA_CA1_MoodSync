using MoodSync.Components;
using MoodSync.Services;
using MoodSync.Interfaces;
using MoodSync.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddScoped<IWeatherService, WeatherService>();
        builder.Services.AddScoped<ILocationService, LocationService>();
        builder.Services.AddScoped<IGeoCodingService, GeoCodingService>();
        builder.Services.AddScoped<RecommendationService>();
        builder.Services.AddScoped<MoodService>();
        builder.Services.AddScoped<LoginStateService>();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 21))));

        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpClient();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapDefaultControllerRoute();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}