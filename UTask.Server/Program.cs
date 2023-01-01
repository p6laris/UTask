using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using UTask.Server.Data;
using UTask.Server.Repos;
using UTask.Server.Repos.Contact;

namespace UTask.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<UTaskDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("UTaskConnection"));
            });
            builder.Services.AddScoped<ITaskReposiotry, TaskRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
                policy.WithHeaders(HeaderNames.ContentType);
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}