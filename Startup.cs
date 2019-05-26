/*
    Run SQL Server as container 
    $ docker pull microsoft/mssql-server-windows-express
    $ docker run -d -p 1433:1433 -e sa_password=mystrongpassword0! -e ACCEPT_EULA=Y --name mssql microsoft/mssql-server-windows-express
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CmdApi.Models;

namespace CmdApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        //public Startup(IConfiguration configuration) => Configuration = configuration;
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json") // Duplicate == Json1
                                                 //.AddJsonFile($"appsettings.{env.EnvironmentName}.json") // Duplicate == Json1
                .AddEnvironmentVariables() // Duplicate == Environment
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CommandContext>
                (opt => opt.UseSqlServer(Configuration["DbConnectionString"]));
            //(opt => opt.UseSqlServer(Configuration["Data:CommandAPIConnection:ConnectionString"]));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
