using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using okhunjonov_shoyatbek_todolist;
using okhunjonov_shoyatbek_todolist.IRepositories;
using okhunjonov_shoyatbek_todolist.Repostories;

namespace okhunjonov_shoyatbek_todolist
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
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<IToDoEntryRepo, ToDoEntryRepo>();
            services.AddScoped<IToDoListRepo, ToDoListRepo>();
            services.AddDbContextPool<ToDoListDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ToDoListDb")));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
