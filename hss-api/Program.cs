using hss_api.Controllers;
using hss_api.DAL;
using hss_api.Db;
using hss_api.Services;

namespace hss_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ==============================================================================================
            // DI
            // ==============================================================================================

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Db
            builder.Services.AddDbContext<SupperContext>();

            // Data access layer
            builder.Services.AddScoped<ISpotRepository, SpotRepository>();

            // Services
            builder.Services.AddScoped<ISpotService, SpotService>();


            // ==============================================================================================
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}