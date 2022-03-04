using AutoMapper;
using AutoMapperMVC;
using Employees.Contracts;
using Employees.Repository;
using Employees.Repository.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmployeesApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _environment = environment;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = _environment.IsDevelopment());

            //---
            // Daniel: Add the cors to comunicate the service with angular
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowWebApp", builder =>
                {
                    builder.WithHeaders("*");
                    builder.WithOrigins("*");
                    builder.WithMethods("*");
                });
            });
            //---

            //---
            // Daniel: Mapper
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();
            //---


            //---
            // service manager
            services.AddScoped<IExternalService, ExternalService>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddHttpClient("ServiceApiExt", c => c.BaseAddress = new System.Uri("http://dummy.restapiexample.com/"));
            //---

            //services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeesApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeesApi v1"));
            }

            app.UseHttpsRedirection();
            //---
            // Daniel: Agregar los cors para comunicar el servicio con angular
            app.UseCors("AllowWebApp");
            //---

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
