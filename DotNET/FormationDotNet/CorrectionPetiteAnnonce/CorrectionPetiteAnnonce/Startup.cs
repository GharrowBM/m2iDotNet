using CorrectionPetiteAnnonce.Interfaces;
using CorrectionPetiteAnnonce.Models;
using CorrectionPetiteAnnonce.Repositories;
using CorrectionPetiteAnnonce.Services;
using CorrectionPetiteAnnonce.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionPetiteAnnonce
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
            services.AddControllersWithViews();
            /*services.AddDbContext<DataContext>();
            services.AddScoped<IRepository<Annonce>, AnnonceRepository>();
            services.AddScoped<IRepository<Utilisateur>, UtilisteurRepository>();
            services.AddTransient<UploadService>();
            services.AddScoped<LoginService>();
            services.AddTransient<FormatService>();*/
            services.AddOurServices();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddCors(options => {
                options.AddPolicy("allConnections", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod();
                });

                options.AddPolicy("specialOrigin", builder =>
                {
                    builder.WithMethods("POST").WithOrigins("http://localhost:3000");
                });
            });
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseCors("specialOrigin");
            app.UseCors();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Annonce}/{action=Index}/{id?}");
            });
        }
    }
}