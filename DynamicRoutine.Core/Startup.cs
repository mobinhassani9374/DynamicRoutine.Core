using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicRoutine.Core.Data;
using DynamicRoutine.Core.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicRoutine.Core
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var conString = "Data Source=WIN-SQL\\MSSQLSERVER2016;Initial Catalog=RiutinBuilderMobin;Persist Security Info=True;User ID=sa; Password=exir@123; MultipleActiveResultSets=True";

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(conString);
            });

            services.AddScoped<UserRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.Migrate();

            DatabaseInitializer.Init(db);

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
