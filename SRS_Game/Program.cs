using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SRS_Game.Data;
using SRS_Game.Services;
using ContosoUniversity.Data;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using SRS_Game.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
})
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en"),
                new CultureInfo("pl")
            };

    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
});

//builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
//builder.Services.AddControllersWithViews()
//        .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
//        .AddDataAnnotationsLocalization();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Register IHttpContextAccessor

// Register the ParticipantService
builder.Services.AddScoped<IReadableParticipant, ParticipantService>();
builder.Services.AddScoped<IWritableParticipant, ParticipantService>();

builder.Services.AddScoped<IReadableProject, ProjectService>();
builder.Services.AddScoped<IWritableProject, ProjectService>();

builder.Services.AddScoped<IReadableDocument, DocumentService>();
builder.Services.AddScoped<IWritableDocument, DocumentService>();

builder.Services.AddScoped<IReadableAttachement, AttachementService>();

builder.Services.AddScoped<IReadableTeam, TeamService>();

builder.Services.AddScoped<IReadableUser, UserService>();

builder.Services.AddDbContext<SRS_GameDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SRS_GameDbContext") ?? throw new InvalidOperationException("Connection string 'SRS_GameDbContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<SRS_GameDbContext>();
        //DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCultures = new[] { "en", "pl" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

localizationOptions.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());

app.UseStatusCodePagesWithReExecute("/NotFound");

app.UseRequestLocalization(localizationOptions);    // Ensure this is before UseRouting

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
