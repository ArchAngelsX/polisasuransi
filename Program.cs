using asuransi_polis.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<PolisService>();

// Configure culture and UI culture
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("fr-FR"),
        new CultureInfo("es-ES"),
        new CultureInfo("de-DE"),
        new CultureInfo("it-IT"),
        new CultureInfo("pt-PT"),
        new CultureInfo("ru-RU"),
        new CultureInfo("zh-CN"),
        new CultureInfo("ja-JP"),
        new CultureInfo("ko-KR"),
        new CultureInfo("id-ID")
    };

    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("id-ID");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

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
app.UseRequestLocalization();
app.MapRazorPages();

app.Run();