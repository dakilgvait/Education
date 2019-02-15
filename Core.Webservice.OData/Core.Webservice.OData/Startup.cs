using Client.OData.Common;
using Client.OData.Config;
using Client.OData.Context;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Client.OData
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.StartupSettings = new StartupDynamicSettings(configuration);
        }

        protected StartupDynamicSettings StartupSettings { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ApplicationConfiguration>(serviceProvider =>
            {
                return this.StartupSettings.AppConfig;
            });
            services.Configure<ApplicationConfiguration>(options =>
            {
                this.StartupSettings.Configuration.Bind("ApplicationSection", options);
            });
            services.AddDbContext<TestContext>(opt =>
            {
                opt.UseSqlServer(this.StartupSettings.ConnectionStringConfig.ConnectionStringBuilder.ConnectionString);
            });
            services.AddOData();
            services.AddMvc();
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
                app.UseHsts();
            }
            app.UseMvc(b =>
            {
                b.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                b.MapODataServiceRoute("ODataTest", "odata", this.StartupSettings.EdmModel.Value);
            });
        }
    }
}