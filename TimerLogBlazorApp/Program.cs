using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TimerLogBlazorApp.Components;
using TimerLogBlazorApp.DB;
using TimerLogBlazorApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// DIÉRÉìÉeÉiÇÃê›íË
builder.Services.AddDIComponents(Assembly.GetExecutingAssembly());

// EF CoreÇÃê›íË
builder.Services.AddDbContext<TimerLogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
