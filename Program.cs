using Microsoft.EntityFrameworkCore;
using Session4.Configurations;
using Session4.Context;
using Session4.Repository;

namespace Session4
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
            string con = builder.Configuration.GetConnectionString("LocalConnectionString");
            builder.Services.AddDbContext<LoanAppDbContext>(options => options.UseSqlServer(con));
            builder.Services.AddScoped<ILoanRepository, LoanRepository>();
            builder.Services.AddAutoMapper(typeof(MapperConfig));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}