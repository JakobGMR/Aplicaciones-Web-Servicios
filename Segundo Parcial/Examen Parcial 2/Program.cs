using MatemApi.Infrastructure;
using MatemApi.Infrastructure.Data;
using MatemApi.Services.Features.Alumnos;
using MatemApi.Services.Features.Clases;
using MatemApi.Services.Features.Tutores;
using MatemApi.Services.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<AlumnoService>();
builder.Services.AddTransient<AlumnoRepository>();
builder.Services.AddScoped<TutorService>();
builder.Services.AddTransient<TutorRepository>();
builder.Services.AddScoped<ClaseService>();
builder.Services.AddTransient<ClaseRepository>();

builder.Services.AddControllers();
builder.Services.AddDbContext<MatemApiDbContext>(
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