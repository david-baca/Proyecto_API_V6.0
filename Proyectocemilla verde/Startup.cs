using Microsoft.EntityFrameworkCore;
using Proyectocemilla_verde.Services.IServices;
using Proyectocemilla_verde.Services.Services;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde
{
    public class Startup
    {
        public Startup(IConfiguration configuration){
            Configuration = configuration;

        }

        public IConfiguration Configuration { get;}

        public void ConfigServ(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AplicationdbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("conexion"));
            });

            services.AddTransient<ICliente, ClienteServices>();
            services.AddTransient<IDepartamento, DepartamentoServices>();
            services.AddTransient<IEmpleado, EmpleadoServices>();
            services.AddTransient<IFacturas, FacturasServices>();
            services.AddTransient<IPuesto, PuestoServices>();
            services.AddTransient<IRol, RolServices>();
            services.AddTransient<IUsuario, UsuarioServices>();


            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }
        public void configu (IApplicationBuilder app, IWebHostEnvironment env)
        {
            //sacado de startup

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            //sacado de startup

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }
            );

        }
    }

}
