global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NeoAPTB.Data;
using NeoAPTB.NeoModels;
using NeoAPTB.TempusModels;
using Radzen;
using NeoAPTB;
using NeoAPTB.Interfaces;
using NeoAPTB.Logic;
using Microsoft.AspNetCore.Authentication;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IPuestosTrabajo, PuestosTrabajoService>();
builder.Services.AddScoped<IEmpresasCentros, EmpresaCentrosService>();
builder.Services.AddScoped<IMontos, MontosService>();
builder.Services.AddScoped<IResumen, ResumenService>();
builder.Services.AddScoped<IPersonal, PersonalService>();
builder.Services.AddScoped<IMaestraData, MaestraData>();
builder.Services.AddScoped<ITempus, TempusServices>();
builder.Services.AddScoped<IGlobalData, GlobalData>();

builder.Services.AddScoped<IRolLogic, RolLogic>();
builder.Services.AddScoped<IRotacionLogic, RotacionLogic>();
builder.Services.AddScoped<DialogService>();//para calendario de radzen
builder.Services.AddScoped<ContextMenuService>();//para notificaciones de radzen
builder.Services.AddScoped<NotificationService>(); ;//para notificaciones de radzen


builder.Services.AddDbContext<DbNeoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Neo")), ServiceLifetime.Transient);

builder.Services.AddDbContext<TempusIiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Tempus")), ServiceLifetime.Transient);


builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

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

//app.UseRouting();
//app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
