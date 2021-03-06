﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CompaniesOperations.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CompaniesOperations.API.Repository;

namespace CompaniesOperations.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Database Services
            services.AddDbContext<CompaniesOperationsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));

            //Middleware Services
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost",
                                        "http://motordenegoios",
                                        "http://serv-292");
                });
            });
            services.Configure<IISOptions>(options => 
            {
                options.ForwardClientCertificate = true;
            });

            //Application Services
            services.AddTransient<ILeadRepository, LeadRepository>();
            services.AddTransient<IManagementRepository, ManagementRepository>();
            services.AddTransient<IManagementStatsRepository, ManagementStatsRepository>();

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(ConfigureJson);
        }

        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
