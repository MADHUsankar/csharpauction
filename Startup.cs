        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using Microsoft.AspNetCore.Builder;
        using Microsoft.Extensions.DependencyInjection;
        using Microsoft.Extensions.Logging;
        using Microsoft.AspNetCore.Http;
        using MySQL.Data.EntityFrameworkCore.Extensions;
        using Microsoft.Extensions.Configuration;
        using Microsoft.AspNetCore.Hosting;
        using csharpbelt.Models;
namespace csharpbelt
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public IConfiguration Configuration { get; set;}
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<auctionContext>(options => options.UseMySQL(Configuration["DBInfo:ConnectionString"]));
            // services.Configure<MySqlOptions>(Configuration.GetSection("DBInfo"));
            services.AddMvc();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
            
        }
    }
}