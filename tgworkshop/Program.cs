using Microsoft.EntityFrameworkCore;
using tgworkshop.database;
using tgworkshop.database.repositories;
using tgworkshop.middleware;
using tgworkshop.shared.config;

var builder = WebApplication.CreateBuilder(args);

// You should add environment to docker if you want to run on docker or we can add env into docker-compose but i didnt implement docker-compose

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(AppEnvironments.ConnectionString));

builder.Services.AddSwaggerGen(c =>{});

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

// Apply pending migrations on startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Context>();

    // Apply migrations
    await context.Database.MigrateAsync();
    Console.WriteLine("Database migration completed.");
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseMiddleware<RequestLoggingMiddleware>();
app.Run();
