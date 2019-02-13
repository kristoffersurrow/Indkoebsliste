using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eksamensopgave2f.Infrastructure;
using Eksamensopgave2f.Interfaces;
using Eksamensopgave2f.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Eksamensopgave2f
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Her defineres CORS
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials()));

            //Laver en dependency af interfacet
            services.AddScoped<IGroceryRepository, GroceryRepository>();
            services.AddDbContext<Eksamensopgave2DBContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("GroceryConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Her bruges CORS
            app.UseCors("CorsPolicy");

            app.UseMvc();
        }
    }
}
