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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Cheeseria.Api.Database.Context;
using Cheeseria.Api.Database.Repositories;
using AutoMapper;
using Cheeseria.Api.Handlers.Abstractions;
using Cheeseria.Api.Dto;
using Cheeseria.Api.Handlers;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace Cheeseria.Api
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

            //for in-memory db testing
            //services.AddDbContext<CheeseDbContext>(opt => opt.UseInMemoryDatabase("cheeseriadb"));

            services.AddDbContext<CheeseSQLiteDBContext>(options => options.UseSqlite(Configuration.GetConnectionString("cs")));

            services.AddScoped<IActionHandlerAsync<CreateCheeseRequest, CreateCheeseResponse>, CheeseCreateHandler>();
            services.AddScoped<IActionHandlerAsync<GetCheeseRequest, IEnumerable<GetCheeseResponse>>, CheeseGetHandler>();

            services.AddScoped<ICheeseRepository, CheeseRepository>();
            // Add service and create Policy with options
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cheeseria.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cheeseria.Api v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
