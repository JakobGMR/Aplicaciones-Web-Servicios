using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SoccerGame.Infrastructure.Data;
using SoccerGame.Infrastructure.Repositories;
using SoccerGame.Services.Features;
using SoccerGame.Services.Mappings;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<JugadorService>();
builder.Services.AddTransient<JugadorRepository>();
builder.Services.AddScoped<PartidoService>();
builder.Services.AddTransient<PartidoRepository>();
builder.Services.AddScoped<TeamService>();
builder.Services.AddTransient<TeamRepository>();

// POSIBLE SALVACION
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers().AddNewtonsoftJson(x => 
 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
builder.Services.AddDbContext<SoccerGameDbContext>(
    options => {
        options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
