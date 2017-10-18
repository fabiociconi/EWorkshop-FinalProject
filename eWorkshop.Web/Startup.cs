using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using XCommon.Application;
using XCommon.Extensions.Util;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Web
{
	public class Startup
    {
		public IConfigurationRoot Configuration { get; }

		public IApplicationSettings ApplicationSettings { get; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.Development.json", optional: true)
				.AddEnvironmentVariables();

			Configuration = builder.Build();
			ApplicationSettings = Configuration.Get<ApplicationSettings>("eWorkshop");
		}

		public void ConfigureServices(IServiceCollection services)
        {
			services
				.AddMvc()
				.AddJsonOptions(options =>
				{
					options.SerializerSettings.ContractResolver = new DefaultContractResolver();
				});
		}

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			Kernel.Map<IApplicationSettings>().To(ApplicationSettings);
			Business.Factory.Register.Do();

			if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseAuthentication()
                .Use(async (context, next) =>
                {
                    await next();

                    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                    {
                        context.Request.Path = "/index.html";
                        await next();
                    }
                })
                .UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } })
                .UseStaticFiles()
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                    name: "api",
                    template: "api/{controller}/{action}/{id?}");
                });
        }
    }
}
