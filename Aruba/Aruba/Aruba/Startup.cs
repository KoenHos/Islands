using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aruba.Data;
using Aruba.CustomMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Aruba.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Aruba.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Aruba
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<IslandDbContext>();

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg =>
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                    }
                );

            services.AddDbContextPool<IslandDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IslandsDb2"));
            });

            services.AddTransient<IMailService, DummyMailService>();
            services.AddTransient<ElementSeeder>();

            // services.AddSingleton<>(); Add one instance for the entire application
            // services.AddTransient<>(); Return a new instance evertime one is needed/being ask for
            // services.AddScoped<>(); One instance per request (good for data access)

            //services.AddSingleton<IIslandData, InMemoryIslandData>();
            services.AddScoped<IIslandDataService, SqlIslandDataService>();

            services.AddScoped<IHolidayCategoryDataService, InMemoryHolidayCategoryDataService>();
            services.AddScoped<IHolidayPackageDataService, InMemoryHolidayPackageDataService>();
            //services.AddScoped<IHolidayCategoryDataService, SqlHolidayCategoryDataService>();
            // services.AddScoped<IHolidayPackageDataService, SqlHolidayPackageDataService>();

            services.AddScoped<IElementDataService, SqlElementDataService>();
            services.AddScoped<IElementSeeder, ElementSeeder>();

            services.AddRazorPages();
            services.AddControllers();
            services.AddControllersWithViews();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules();

            app.UseAuthentication(); // need to be before Routing and Enpoints congiguration!
            app.UseAuthorization();

            app.UseSecurityMiddleware();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                // endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });

        }

        public RequestDelegate WelcomeToGreenland(RequestDelegate next)
        {
            return async ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/Green"))
                {
                    await ctx.Response.WriteAsync("Welcome to Greenland; you were intercepted by custom middleware");
                }
                else
                {
                    await next(ctx);
                }
            };
        }

    }
}
