using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionPersonal.Areas.v2.Entities;
using GestionPersonal.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GestionPersonal.Areas.v2.Services;
using AutoMapper;

namespace GestionPersonal
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddDbContext<GPS_Logic.Data.DireccionContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("Default")); });
            //services.AddDbContext<GPS_Logic.Data.SociedadContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("Default")); });
            //services.AddTransient

            //services.Configure<GPDataInformation.GestionPersonal>(options => {
            //    options.StringConnectionDb = Configuration.GetConnectionString("Default");

            //});
            // agregar context de entity framework

            string is_production_mode = Configuration.GetSection("ModeProduction").Value;
            string GPS_con = is_production_mode == "true" ? Configuration.GetConnectionString("Production") : Configuration.GetConnectionString("test");

            services.AddDbContext<GPSctx>(options =>
                options.UseSqlServer(GPS_con));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:89").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(7200);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;

            });
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IFormacion, FormacionServ>();
            services.AddScoped<ICF_Evaluacion, CF_EvaluacionServ>();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();
            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=DoLogin}/{id?}");
                routes.MapControllerRoute(
                    name: "default",
                    pattern: "{area:exists}/{controller=Login}/{action=DoLogin}/{id?}");
            });
           
            // Configuramos Rotativa indicándole el Path RELATIVO donde se
            // encuentran los archivos de la herramienta wkhtmltopdf.
            Rotativa.AspNetCore.RotativaConfiguration.Setup(env);
        }
    }
}
