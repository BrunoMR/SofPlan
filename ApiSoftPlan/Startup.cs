﻿namespace ApiSoftPlan
{
	using System.IO;

	using ApiSoftPlan.Core;
	using ApiSoftPlan.Models;

	using AutoMapper;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Versioning;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.PlatformAbstractions;

	using Newtonsoft.Json.Serialization;

	using Swashbuckle.AspNetCore.Swagger;

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
			services.AddOptions();

			services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins",
					builder =>
					{
						builder
							.AllowAnyOrigin()
							.AllowAnyHeader()
							.AllowAnyMethod();
					});
			});

			services.Configure<Settings>(Configuration.GetSection("Settings"));
			services.AddScoped<IMathCore, MathCore>();
			services.AddRouting(options => options.LowercaseUrls = true);

			// Configurando o serviço de documentação do Swagger
			services.AddSwaggerGen(c =>
				{
					c.SwaggerDoc("v1",
						new Info
							{
								Title = "SoftPlan Test",
								Version = "v1",
								Description = "API REST criada para teste da SoftPlan",
								Contact = new Contact
									          {
										          Name = "Bruno Machado",
										          Url = "https://github.com/BrunoMR/SofPlan"
								}
							});

					var caminhoAplicacao =
						PlatformServices.Default.Application.ApplicationBasePath;
					var nomeAplicacao =
						PlatformServices.Default.Application.ApplicationName;
					var caminhoXmlDoc =
						Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

					c.IncludeXmlComments(caminhoXmlDoc);
				});

			services.AddApiVersioning(config =>
			{
				config.ReportApiVersions = true;
				config.AssumeDefaultVersionWhenUnspecified = true;
				config.DefaultApiVersion = new ApiVersion(1, 0);
				config.ApiVersionReader = new HeaderApiVersionReader("api-version");
			});

			services.AddAutoMapper();
			services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");
			services.AddMvc()
				.AddJsonOptions(options =>
				{
					options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Ativando middlewares para uso do Swagger
			app.UseSwagger();
			app.UseSwaggerUI(
				c =>
					{
						c.SwaggerEndpoint("/swagger/v1/swagger.json", "SoftPlan Test");
						c.RoutePrefix = string.Empty;
					});

			app.UseMvc();
		}
	}
}
