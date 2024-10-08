using MoodSync.Components;
using MoodSync;
using MoodSync.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register WeatherService for dependency injection
//builder.Services.AddScoped<WeatherService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<GeocodingService>();
// Registers HttpClient for use in WeatherService
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
