using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.IoC;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        //This method gets called by the runtime. Use this method to add services to the container

        public void ConfigureServices(IServiceCollection services) 
        {

            services.AddInfrastructure(Configuration);
            services.AddControllersWithViews();
        }

        //This method gets called by the runtime. Use this method to configure the HTTP request

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
