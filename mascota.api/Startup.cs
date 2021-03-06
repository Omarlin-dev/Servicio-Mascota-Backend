using mascota.datos;
using mascota.servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace mascota.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private string nameCors = "mascotaCors";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "mascota.api", Version = "v1" });
            });

            services.AddDbContext<DbMascotaContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("cadenaConexion")),
                ServiceLifetime.Transient
            );

            services.AddCors(option =>
            {
                option.AddPolicy(this.nameCors,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200/")
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader();
                    });
            });

            services.AddScoped<IMascotaRepositorio, MascotaRepositorio>();
            services.AddScoped<IMascotaServicio, MascotaServicio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "mascota.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(this.nameCors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
