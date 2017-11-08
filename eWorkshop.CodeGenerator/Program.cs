using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using XCommon.Application;
using XCommon.CodeGenerator;
using XCommon.CodeGenerator.Angular.Configuration;
using XCommon.CodeGenerator.Core;
using XCommon.CodeGenerator.CSharp.Configuration;
using XCommon.CodeGenerator.TypeScript.Configuration;
using XCommon.Extensions.Util;

namespace eWorkshop.CodeGenerator
{
	class Program
	{
		private static IApplicationSettings ApplicationSettings { get; set; }

		public static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "eWorkshop.Web"))
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile("appsettings.Development.json", optional: true);

			var config = builder.Build();
			ApplicationSettings = config.Get<ApplicationSettings>("eWorkshop");
			//var x = new List<string> { "-t" };
			var gen = new Generator(GetConfig());
			gen.Run(args);
		}

		static GeneratorConfig GetConfig()
		{
			var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..");

			var web = "eWorkshop.Web";
			var entity = "eWorkshop.Entity";
			var data = "eWorkshop.Data";
			var business = "eWorkshop.Business";

			return new GeneratorConfig
			{
				Angular = new AngularConfig
				{
					Path = Path.Combine(basePath, web, "app", "modules"),
					QuoteType = QuoteType.Double
				},
				TypeScript = new TypeScriptConfig
				{
					Entity = new TypeScriptEntityConfig
					{
						Path = Path.Combine(basePath, web, "app", "entity"),
						Assemblys = new List<Assembly> { typeof(Entity.Enum.RoleType).Assembly }
					}
				},
				DataBase = new DataBaseConfig
				{
					ConnectionString = ApplicationSettings.DataBaseConnectionString
				},
				CSharp = new CSharpConfig
				{
					Factory = new CSharpProjectConfig
					{
						Execute = true,
						NameSpace = business + ".Factory",
						Path = Path.Combine(basePath, business, "Factory")
					},
					Repository = new CSharpRepositoryConfig
					{
						Execute = true,
						Concrecte = new CSharpProjectConfig
						{
							Execute = true,
							NameSpace = business,
							Path = Path.Combine(basePath, business)
						}
					},
					EntityFramework = new CSharpEntityFrameworkConfig
					{
						Execute = true,
						ContextName = "eWorkConext",
						NameSpace = data,
						Path = Path.Combine(basePath, data),
						Remap = GetRemap()
					},
					Entity = new CSharpEntityConfig
					{
						Execute = true,
						ExecuteEntity = true,
						ExecuteFilter = true,
						Path = Path.Combine(basePath, entity),
						NameSpace = entity
					}
				}
			};
		}

		private static List<CSharpDataBaseRemap> GetRemap()
		{
			return new List<CSharpDataBaseRemap>
			{
				 new CSharpDataBaseRemap
				{
					Schema = "Register",
					Table = "PeopleAddresses",
					Column = "Type",
					NameSpace = "eWorkshop.Entity.Enum",
					Type = "AddressType"
				},

				new CSharpDataBaseRemap
				{
					Schema = "Register",
					Table = "Users",
					Column = "Role",
					NameSpace = "eWorkshop.Entity.Enum",
					Type = "RoleType"
				},
			};
		}
	}
}
