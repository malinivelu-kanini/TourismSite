using Microsoft.EntityFrameworkCore;
using TourFeedBackApp.Interfaces;
using TourFeedBackApp.Models;
using TourFeedBackApp.Services;

namespace TourFeedBackApp
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
            builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("myconn")));

            #region
            builder.Services.AddScoped<IRepo<int, FeedBack>, FeedBackRepo>();
            builder.Services.AddScoped<IFeedBack, FeedBackService>();

            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("ReactCors", policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
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

            app.UseCors("ReactCors");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}