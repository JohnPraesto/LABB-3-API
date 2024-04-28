
using LABB_3_API.Controllers;
using LABB_3_API.Data;
using LABB_3_API.Services;
using LABB_3_API_Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LABB_3_API
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

            builder.Services.AddScoped<ILabb3Api<Person>, PersonRepository>();
            builder.Services.AddScoped<IHobbies<Hobby>, HobbyRepository>();
            builder.Services.AddScoped<IPHConnections<PersonHobbyConnection>, ConnectionRepository>();

            builder.Services.AddDbContext<Labb3ApiDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

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
