using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatycznyPodlewacz.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;


namespace AutomatycznyPodlewacz
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
		services.AddControllers();
            services.AddSingleton<ISensorService, SensorService>();
            services.AddSingleton<IPumpService, PumpService>();
            services.AddSingleton<ISystemService, SystemService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
	app.UseRouting();

	app.UseEndpoints(endpoints => {
		endpoints.MapControllers();
	});

           
        }
    }
}
