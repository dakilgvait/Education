using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Person.DAL.UnitOfWork;
using Person.Service;
using Person.Service.Abstraction;
using ServiceStack.Redis;
using System;
using System.IO;
using Unity;

namespace DashboardApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(AppContext.BaseDirectory))
               .AddJsonFile("appsettings.json", optional: true)
               .Build();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IUnityContainer>(this.InitializeUnityContainer(config));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        protected IUnityContainer InitializeUnityContainer(IConfigurationRoot config)
        {
            IUnityContainer container = new UnityContainer();
            BaseService.InitializeContainer(container);
            ApplicationUOW.InitializeContainer(container);
            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IGenderService, GenderService>();
            container.RegisterInstance<IRedisClientsManager>(this.InitializeRedisClientsManager(config));
            return container;
        }

        protected IRedisClientsManager InitializeRedisClientsManager(IConfigurationRoot config)
        {
            Uri uri = new Uri(config["RedisConnectionString:Main"]);
            string connectionUrl = $"{uri.Scheme}://{uri.Authority}?password={uri.UserInfo.Split(':')[1]}";
            return new RedisManagerPool(connectionUrl);
        }
    }
}