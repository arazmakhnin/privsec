
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserManagerApp.Server.Configuration;
using UserManagerApp.Server.DAL;
using UserManagerApp.Server.Services;

namespace UserManagerApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<MongoDbConfiguration>(builder.Configuration.GetSection("MongoDb"));
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IMongoClient>(s => new MongoClient(s.GetRequiredService<IOptions<MongoDbConfiguration>>().Value.ConnectionString));
            builder.Services.AddTransient<IMongoDatabase>(s => s.GetRequiredService<IMongoClient>().GetDatabase(s.GetRequiredService<IOptions<MongoDbConfiguration>>().Value.Database));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
