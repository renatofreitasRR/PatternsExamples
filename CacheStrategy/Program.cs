using CacheStrategy.Repositories;
using CacheStrategy.Repositories.Caching;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Cache Strategy",
        Description = "Swagger",
        Contact = new OpenApiContact()
        {
            Name = "Renato Freitas",
            Email = "natogfreitas@gmail.com",
        },
    });

});

builder.Services.AddMemoryCache();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<IPersonRepository, PersonCachingDecorator<PersonRepository>>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cache Strategy");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
