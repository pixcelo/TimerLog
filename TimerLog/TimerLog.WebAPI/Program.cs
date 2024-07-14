using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TimerLog.WebAPI.DB.Contexts;
using TimerLog.WebAPI.Extensions;

// ���O�t��CORS�|���V�[
var timerLogOrigins = "timerLogOrigins";

var builder = WebApplication.CreateBuilder(args);

// CORS�|���V�[�̐ݒ�
builder.Services.AddCors(options =>
{
    options.AddPolicy(timerLogOrigins,
        builder =>
        {
            builder.WithOrigins(
                "https://localhost:7177",
                "https://localhost:7291")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI�R���e�i�̐ݒ�
builder.Services.AddDIComponents(Assembly.GetExecutingAssembly());

// EF Core�̐ݒ�
builder.Services.AddDbContext<StopwatchLogsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ���O�t��CORS�|���V�[���w��
app.UseCors(timerLogOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
