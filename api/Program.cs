
using api.Map;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
<<<<<<< HEAD
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
            builder.Services.AddAutoMapper(typeof(MapperConfig));
            builder.Services.AddDbContext<project_prn231Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    if (!context.Response.Headers.ContainsKey("Content-Type"))
                    {
                        context.Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
                    }
                    else
                    {
                        // Ensure charset=utf-8 is included in the Content-Type header
                        var contentType = context.Response.Headers["Content-Type"].ToString();
                        if (!contentType.ToLower().Contains("charset=utf-8"))
                        {
                            context.Response.Headers["Content-Type"] = contentType + "; charset=utf-8";
                        }
                    }
                    return Task.CompletedTask;
                });

                await next.Invoke();
            });

            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            //    await next.Invoke();
            //});

            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials()); // allow credentials

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
