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
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

			services
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, cfg =>
				{
					cfg.RequireHttpsMetadata = false;
					cfg.SaveToken = true;

					cfg.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidIssuer = AppConstants.TokenAudience,
						ValidAudience = AppConstants.TokenAudience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConstants.TokenKey))
					};
				});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "eWorkShop API", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
				{
					Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
					Name = "Authorization",
					In = "header",
					Type = "apiKey"
				});
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

			app
				.UseSwagger()
				.UseSwaggerUI(c =>
				{
					c.ShowJsonEditor();
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "eWorkShop API");
				});
		}
	}
}
