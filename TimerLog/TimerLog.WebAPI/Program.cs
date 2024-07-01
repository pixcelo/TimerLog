using TimerLog.WebAPI.Repositoriers;
using TimerLog.WebAPI.Services;

// 名前付きCORSポリシー
var timerLogOrigins = "timerLogOrigins";

var builder = WebApplication.CreateBuilder(args);

// CORSポリシーの設定
builder.Services.AddCors(options =>
{
    options.AddPolicy(timerLogOrigins,
        builder =>
        {
            builder.WithOrigins("https://localhost:7040")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DIコンテナの設定
builder.Services.AddTransient<ITimerLogService, TimerLogService>();
builder.Services.AddTransient<ITimerLogRepository, TimerLogRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 名前付きCORSポリシーを指定
app.UseCors(timerLogOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
