using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Practico1.BusinessLogic;
using Practico1.DataAccess;
using Practico1.IBusinessLogic;
using Practico1.IDataAccess;

namespace Practico1.WebAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowEverything", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddControllers();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            string directory = System.IO.Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile("appsettings.json")
            .Build();
            var connectionString = configuration.GetConnectionString("UsersDBConnectionString");
            services.AddDbContext<ContextDb>(options =>
            options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
