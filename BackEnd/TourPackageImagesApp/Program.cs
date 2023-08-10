using Microsoft.EntityFrameworkCore;
using TourPackageImagesApp.Interfaces;
using TourPackageImagesApp.Models;
using TourPackageImagesApp.Services;

namespace TourPackageImagesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #region
            builder.Services.AddDbContext<TourImageContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("connect")));
            builder.Services.AddScoped<IRepo<int, TourImages>, TourImageRepo>();
            builder.Services.AddScoped<ITourImageService, ToursImageServices>();
            builder.Services.AddScoped<IRepo<int, Tour>, TourRepo>();
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("CORS", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CORS");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}