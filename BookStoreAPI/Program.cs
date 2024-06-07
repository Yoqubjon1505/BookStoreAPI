
using BookStoreAPI.Infrastructure;
using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Repositories;
using BookStoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;


namespace BookStoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionStringsSQL")));



            // Add services to the container.
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddScoped<BookService>();
            builder.Services.AddScoped<AuthorService>();
            builder.Services.AddScoped<BookAuthorService>();
            builder.Services.AddScoped<CategoryService>();

            builder.Services.AddControllers();
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

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
