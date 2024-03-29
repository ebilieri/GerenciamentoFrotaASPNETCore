﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frota.Application;
using Frota.Application.Interfaces;
using Frota.Domain.Interfaces.IRepositories;
using Frota.Domain.Interfaces.IServices;
using Frota.Domain.Services;
using Frota.Repository.Context;
using Frota.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frota.WebAPP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                //.AddJsonFile("appstting.json", optional: false, reloadOnChange: true)
                .AddJsonFile("config.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var sqlConnection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<FrotaContext>(options =>
                options.UseSqlServer(sqlConnection));

            // Application
            services.AddScoped<IVeiculoApplication, VeiculoApplication>();

            // Services
            services.AddScoped<IVeiculoService, VeiculoService>();

            // Repostories
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();


            AutoMapper.Mapper.Initialize((cfg) =>
            {
                cfg.AddProfile<Application.Mappings.MappingProfile>();
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Veiculo}/{action=Index}/{id?}");
            });
        }
    }
}
