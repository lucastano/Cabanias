
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OBLIGATORIO1_P3.ACCESODATOS;
using OBLIGATORIO1_P3.ACCESODATOS.EntitiFramework;
using OBLIGATORIO1_P3.APLICACION.CasosUso;
using OBLIGATORIO1_P3.APLICACION.InterfacesCasoUso;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios;

using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace OBLIGATORIO2_P3.WEB_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Add dbcontext

            builder.Services.AddDbContext<ObligatorioContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("ObligatorioContext"));


            });
            // Add use case and repositori.
            //repositorios ef 
            builder.Services.AddScoped<ICabaniaRepositorio, CabaniaEFRepositorio>();
            builder.Services.AddScoped<IMantenimientoRepositorio, MantenimientoEFRepositorio>();
            builder.Services.AddScoped<ITipoRepositorio, TipoEFRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio,UsuarioEFRepositorio>();

            //Casos de uso
            //UC DE TIPO INTERFACE CASO DE USO Y CLASE CONCRETA
            builder.Services.AddScoped<IAltaTipo, AltaTipo>();
            builder.Services.AddScoped<IEliminarTipo, EliminarTipo>();
            builder.Services.AddScoped<IObtenerTipo, ObtenerTipo>();
            builder.Services.AddScoped<IObtenerTodosTipos, ObtenerTodosTipos>();
            builder.Services.AddScoped<ITipoPorNombre, TipoPorNombre>();
            builder.Services.AddScoped<IEditarTipo, EditarTipo>();

            //UC DE CABANIA INTERFACE CASO DE USO Y CLASE CONCRETA
            builder.Services.AddScoped<IAltaCabania, AltaCabania>();
            builder.Services.AddScoped<IObtenerListaCabaniasHabilitadas, ObtenerListaCabaniasHabilitadas>();
            builder.Services.AddScoped<IObtenerListaCabaniasMaxPer, ObtenerListaCabaniasMaxPer>();
            builder.Services.AddScoped<IObtenerListaCabaniasNombre, ObtenerListaCabaniasNombre>();
            builder.Services.AddScoped<IObtenerListaCabaniasTipo, ObtenerListaCabaniasTipo>();
            builder.Services.AddScoped<IObtenerTodasCabanias, ObtenerTodasCabanias>();
            builder.Services.AddScoped<IObtenerCabaniaPorNumeroHabitacion, ObtenerCabaniaPorNumeroHabitacion>();
            builder.Services.AddScoped<IObtenerCabaniaPorTipoYMonto,ObtenerCabaniaPorTipoYMonto>();
            builder.Services.AddScoped<IObtenerCabaniaPorTipoYMonto, ObtenerCabaniaPorTipoYMonto>();

            builder.Services.AddScoped<IObtenerMantenimientosPorValor, ObtenerMantenimientosPorValor>();



            //UC OBTENER TODOS LOS TIPOS DE CABANIA 
            builder.Services.AddScoped<IObtenerTodosTipos, ObtenerTodosTipos>();
            builder.Services.AddScoped<IObtenerTipo, ObtenerTipo>();

            //UC DE MANTENIMIENTOS 
            builder.Services.AddScoped<IAltaMantenimiento, AltaMantenimiento>();
            builder.Services.AddScoped<IObtenerListaMantenimientos, ObtenerListaMantenimientos>();
            builder.Services.AddScoped<IObtenerListaMantenimientosCabania, ObtenerListaMantenimientosCabania>();
            builder.Services.AddScoped<IObtenerListaMantenimientosCabaniaEntreFechas, ObtenerListaMantenimientosCabaniaEntreFechas>();

            //UC DE USUARIOS Y LOGIN
           
            builder.Services.AddScoped<IAgregarUsuario, AgregarUsuario>();
            builder.Services.AddScoped<IObtenerUsuario,ObtenerUsuario>();
            builder.Services.AddScoped<IValidarPassword, ValidarPassword>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen( opciones=>
            {
                opciones.SwaggerDoc("v1", new OpenApiInfo { Title = "Obligatorio APi", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory,xmlFile);
                opciones.IncludeXmlComments(xmlPath);

                opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Description = "autorizacion std mediante esquema bearer",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                opciones.OperationFilter<SecurityRequirementsOperationFilter>();

            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opciones =>
            {
                opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:SecretTokenKey").Value!)),
                    ValidateIssuer = false,
                     ValidateAudience=false
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //siemrpe antes de la autorizacion
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}