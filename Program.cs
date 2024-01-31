using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Controllers;
using WebApiTest.EntityModels;
using WebApiTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<BookService>();
builder.Services.AddSingleton<MusicService>();
builder.Services.AddSingleton<VideoGameService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<BillingTimeContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("database")));

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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

app.UseAuthorization();

app.MapControllers();

app.Run();