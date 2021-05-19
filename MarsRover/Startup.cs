using FluentValidation;
using MarsRover.CommandValidators;
using MarsRover.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace MarsRover
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
            services.AddControllersWithViews();
            services.AddSingleton<IRoverActionService, RoverActionService>();
            services.AddSingleton<ICalculateFinalPositionCommandValidator, CalculateFinalPositionCommandValidator>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); 
            services.AddMediatR(typeof(Startup));
            //services.AddCommandValidators(new[] { typeof(Startup).Assembly });
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

            app.Use(async (ctx, next) =>
            {
                try
                {
                    await next();
                }
                catch (ValidationException e)
                {
                    var response = ctx.Response;
                    if (response.HasStarted)
                        throw;
                    response.StatusCode = 400;
                    response.ContentType = "application/json";
                    await response.WriteAsync(JsonConvert.SerializeObject(new
                    {
                        Message = "Opps.. Something went terribly wrong!",
                        ModelState = e.Errors.ToDictionary(error => error.ErrorCode, error => error.ErrorMessage)
                    }), Encoding.UTF8, ctx.RequestAborted);
                }
            });

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
