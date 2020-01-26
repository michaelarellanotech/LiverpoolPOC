using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using MOQdigital.LHAntenatal.DataLayer.Model;
using MOQdigital.LHAntenatal.DataLayer;
using GeofencePOC.Services;
using Wkhtmltopdf.NetCore;
using MOQdigital.LHAntenatal.API.Services;

namespace GeofencePOC
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<LiverpoolContext>(options => options.UseSqlServer("Server=MD-R90Q8NH0\\LOCALSQL;Database=Liverpool;User Id=sa;Password=sa;"));
            
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IPDFService, PDFService>();
        
            services.AddWkhtmltopdf();
            services.AddHttpClient();
            
           // MvcOptions.EnableEndpointRouting = false;

            services.AddCors(o => o.AddPolicy("allowAllPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("allowAllPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
