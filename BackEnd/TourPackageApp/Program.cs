using Microsoft.EntityFrameworkCore;
using TourPackageApp.Interfaces;
using TourPackageApp.Models;
using TourPackageApp.Services;

namespace TourPackageApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("ReactCors", policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region
            //connecting to database
            builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("mycon")));
            #endregion

            #region
            // dependency injection 
            builder.Services.AddScoped<IRepo<int, Tours>, ToursRepo>();
            builder.Services.AddScoped<IRepo<int, Inclusion>, InclusionRepo>();
            builder.Services.AddScoped<IRepo<int, TotalDaysDescription>, TotalDaysDescriptionRepo>();
            builder.Services.AddScoped<IServices, TourServices>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("ReactCors");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();


            app.Run();
        }
    }
}