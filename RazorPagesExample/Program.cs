using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Localization;
using RazorPagesExample.Localization;

var builder = WebApplication.CreateBuilder(args);

// Configure localization
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

const string defaultCulture = "en";

var supportedCultures = new[]
{
    new CultureInfo(defaultCulture),
    new CultureInfo("tr")
};

builder.Services.Configure<RequestLocalizationOptions>(options => {
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    // options.RequestCultureProviders = new List<IRequestCultureProvider>
    // {
    //     new MyCustomRequestCultureProvider()
    // };
    
});

builder.Services.AddTransient<ISharedViewLocalizer, SharedViewLocalizer>();

// Add services to the container.

builder.Services.AddRazorPages().AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
        return factory.Create("SharedResource", assemblyName.Name);
    };
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

app.UseRequestLocalization();

app.UseAuthorization();

app.MapRazorPages();

app.Run();