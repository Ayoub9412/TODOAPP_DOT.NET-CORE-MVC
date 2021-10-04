using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOAPP_DOTNETCOREMVC.Models;
using TODOAPP_DOTNETCOREMVC.Models.AppRepository;
using Microsoft.EntityFrameworkCore;
using TODOAPP_DOTNETCOREMVC.Data;

namespace TODOAPP_DOTNETCOREMVC
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
            services.AddRazorPages();

            // uncomment when using the Repository that deals with SQL Server Database
            // make sure you have this packages installed:
            // 1- Entity framework core,
            // 2- entity framework core for sql server,
            // 3- Entity framework core Tools
            // 
            /// use this commands the package manager console after adding the connection string
            /// add-migration "Initial_Create"
            /// update-database
            /// 
            services.AddScoped<IMyTodoListRepository<MyToDoList>, DBToDoListRepository>();
            services.AddScoped<IMyTodoListRepository<MyTodoTask>, DbTaskRepository>();
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            // enable when using  the repository that deals with in memory list
            // disable above services to ignore them
            //services.AddSingleton<IMyTodoListRepository<MyToDoList>, MyToDoListRepository>();
            //services.AddSingleton<IMyTodoListRepository<MyTodoTask>, MyListTaskRepository>();




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

            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern:"{controller=MyToDoList}/{action=Index}/{Id?}"
                    );
            });
        }
    }
}
