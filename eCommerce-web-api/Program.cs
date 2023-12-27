using eCommerce_web_api.Database;
using eCommerce_web_api.Services;
using eCommerce_web_api.Services.Categories;
using eCommerce_web_api.Services.Products;
using Microsoft.EntityFrameworkCore;

namespace eCommerce_web_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            //1.category services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            //2.database service 
            builder.Services.AddDbContextPool<DatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("mydb"));
            });
            //3.product services
            builder.Services.AddScoped<IProductService, ProductService>();





            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            
            //3.cors policy to avoid cross origin error
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy=>
                    {
                        policy.WithOrigins("http://localhost:4200");
                    });

            });






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors();


            app.MapControllers();

            app.Run();
        }
    }
}