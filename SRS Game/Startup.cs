//using Microsoft.AspNetCore.Authentication.OpenIdConnect;
//using Microsoft.EntityFrameworkCore;
//using SRS_Game.Data;
//using SRS_Game.Services;
//using Microsoft.Identity.Web;


//namespace SRS_Game
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
//        {
//            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//                .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"));

//            services.AddControllersWithViews();

//            // Register Services
//            services.AddControllersWithViews();
//            services.AddScoped<IReadableDocument, DocumentService>();
//            services.AddScoped<IWritableDocument, DocumentService>();
//            services.AddScoped<IReadableSqlFile, SqlFileService>();
//            services.AddScoped<IWritableSqlFile, SqlFileService>();

//            //services.AddScoped<IAuthorService, AuthorService>();
//            //services.AddScoped<IPublisherService, PublisherService>();
//            //services.AddScoped<IBookService, BookService>();

//            services.AddDbContext<SRS_GameDbContext>(options =>
//                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            // Configure the HTTP request pipeline.
//            if (!env.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Home}/{action=Index}/{id?}");
//                endpoints.MapControllers();
//            });
//        }
//    }
//}
