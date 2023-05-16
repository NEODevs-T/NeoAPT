using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using NeoAPTB.Data;
using NeoAPTB.NeoModels;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<PuestosTrabajoInterface, PuestosTrabajoService>();
builder.Services.AddScoped<EmpresasCentrosInteface, EmpresaCentrosService>();
builder.Services.AddScoped<MontosInterface, MontosService>();
builder.Services.AddScoped<ResumenInterface, ResumenService>();
builder.Services.AddScoped<PersonalInterface, PersonalService>();
builder.Services.AddScoped<APIInterface, APIService>();
builder.Services.AddScoped<DialogService>();//para calendario de radzen
builder.Services.AddScoped<ContextMenuService>();//para notificaciones de radzen
builder.Services.AddScoped<NotificationService>(); ;//para notificaciones de radzen


builder.Services.AddDbContext<DbNeoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Neo")), ServiceLifetime.Transient);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
