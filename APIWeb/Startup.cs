using APIWeb.BL.Contracts;
using APIWeb.BL.Implementations;
using APIWeb.DAL.Models;
using APIWeb.DAL.Repositories.Contracts;
using APIWeb.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;
using System.Text;

namespace APIWeb
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

            //Para habilitar CORS en nuestra API
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            //Inyecci�n del Contexto - �nica clase que se inyecta sin interfaz
            services.AddDbContext<InitialDContext>(opts => opts.UseMySql(Configuration["ConnectionString:InitialD"]));

            //Aqu� las inyecciones: Interfaz - Clase
            services.AddScoped<IUsuarioBL, UsuarioBL>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVehiculoBL, VehiculoBL>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc(options => options.EnableEndpointRouting = false);

            // REGISTRAMOS SWAGGER COMO SERVICIO
            services.AddOpenApiDocument(document =>
            {
                document.Title = "T�tulo del Web API";
                document.Description = "Descripci�n del Web API.";

                // CONFIGURAMOS LA SEGURIDAD JWT PARA SWAGGER,
                // PERMITE A�ADIR EL TOKEN JWT A LA CABECERA.
                document.AddSecurity("JWT", Enumerable.Empty<string>(),
                    new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Copia y pega el Token en el campo 'Value:' as�: Bearer {Token JWT}."
                    }
                );

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // SWAGGER
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();

            // A�ADIMOS EL MIDDLEWARE DE AUTENTICACI�N
            // DE USUARIOS AL PIPELINE DE ASP.NET CORE
            app.UseAuthentication();

            // A�ADIMOS EL MIDDLEWARE DE SWAGGER (NSwag)
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvc();
            //SWAGGER
        }
    }
}
