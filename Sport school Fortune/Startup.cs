using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sport_school_Fortune.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sport_school_Fortune.Data;

namespace Sport_school_Fortune
{
    public class Startup
    {

        private IConfigurationRoot _confString;

        public Startup(IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // регистрация модулей, плагинов
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddMvc(option => option.EnableEndpointRouting = false); // подключаем поддержку MVC




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage(); // отображение страниц с ошибками
            app.UseStatusCodePages(); // отображение кода страниц
            app.UseStaticFiles(); // отображение CSS-файлов, картинки и т.д. Отображение всех статических файлов в проекте
            app.UseMvcWithDefaultRoute(); // если будет какая то ошибка, то будет использоваться дефолтный URL адрес

            SchoolContext content;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                content = scope.ServiceProvider.GetRequiredService<SchoolContext>();
                DBInitializer.Initial(content);
            }

            app.UseRouting();   // Подключение EndpointRoutingMiddleware
            app.UseAuthorization();  // Подключение EndpointMiddleware
            app.UseEndpoints(endpoints =>
            {
                // определение маршрутов
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
