using Proyectocemilla_verde;

var builder = WebApplication.CreateBuilder(args);

//eliminado y puesto en startup
//if (env.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();


// Add services to the container.
//eliminacion de 3 lines code


//eliminacion de if y su sub clase


var startup = new Startup(builder.Configuration);
startup.ConfigServ(builder.Services);

var app = builder.Build();

startup.configu(app, app.Environment);
app.Run();


//ya implementados en startup
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
