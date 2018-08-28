using System;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ESX.Test.Case.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddIOCConteiner(this.Configuration);
			
			services.AddMvc().AddJsonOptions(options 
				=> options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);

			services.AddGzipCompression();

			services.AddElmahIo(options =>
			{
				options.ApiKey = "c198d9a3404a49acbccff911ec680026";
				options.LogId = new Guid("989d44e2-dfbe-4b19-81ce-84ec689916f9");
			});

			services.AddApiVersioning();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			app.UseElmahIo();
			app.UseResponseCompression();
			app.UseMvc();
		}
	}
}
