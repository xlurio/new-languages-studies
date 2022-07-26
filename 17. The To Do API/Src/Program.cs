namespace ToDoAPI;

using ToDoAPI.Adapters;
using ToDoAPI.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ToDoContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("SampleDatabase")
            ));
        builder.Services.AddScoped<ToDoContext>();

        // Add services to the container.
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddControllers().AddNewtonsoftJson();

        // Learn more about configuring Swagger/OpenAPI at
        // https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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