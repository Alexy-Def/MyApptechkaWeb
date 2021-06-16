using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApptechkaWeb.EfStuff;
using MyApptechkaWeb.EfStuff.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyApptechkaWeb
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
            var connectionString = Configuration.GetValue<string>("connectionString");
            services.AddDbContext<MyApptechkaDbContext>(x => x.UseSqlServer(connectionString));

            services.AddControllersWithViews();

            RegistrationRepositories(services);
        }

        private void RegistrationRepositories(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes();

            foreach (var iRepo in types.Where(type =>
                type.IsInterface
                && type.GetInterfaces()
                    .Any(x =>
                        x.IsGenericType
                        && x.GetGenericTypeDefinition() == typeof(IBaseRepository<>))
                ))
            {
                var realization = types.Single(x => x.GetInterfaces().Contains(iRepo));
                services.AddScoped(
                    iRepo,
                    diContainer =>
                    {
                        var constructor = realization.GetConstructors()[0];
                        var paramInfoes = constructor.GetParameters();

                        var paramValues = new object[paramInfoes.Length];
                        for (int i = 0; i < paramInfoes.Length; i++)
                        {
                            var paramInfo = paramInfoes[i];
                            var paramValue = diContainer.GetService(paramInfo.ParameterType);
                            paramValues[i] = paramValue;
                        }

                        var answer = constructor.Invoke(paramValues);
                        return answer;
                    });
            }
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
