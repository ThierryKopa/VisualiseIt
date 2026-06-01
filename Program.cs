using HAK_BlazorPicoTemplate.Components;
using HAK_BlazorPicoTemplate.Database;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace HAK_BlazorPicoTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddDbContextFactory<UserDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // 1. Lokalisierungs-Dienst hinzufügen und Ordnername definieren
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            var app = builder.Build();

            // 2. Unterstützte Sprachen definieren
            var supportedCultures = new[] { "de", "en" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0]) // Deutsch als Standard
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            // 3. Middleware aktivieren (Wichtig: Vor anderen Routing/Auth-Middlewares!)
            app.UseRequestLocalization(localizationOptions);

            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.MapGet("/Culture/Set", (string culture, string redirectUri, HttpContext httpContext) =>
            {
                if (culture != null)
                {
                    httpContext.Response.Cookies.Append(
                        CookieRequestCultureProvider.DefaultCookieName,
                        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                        new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                    );
                }

                return Results.Redirect(redirectUri);
            });

            app.Run();
        }
    }
}
