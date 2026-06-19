global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NeoAPTB.Data;
using NeoAPTB.NeoModels;
using NeoAPTB.TempusModels;
using NeoAPTB.ModelsSPI;
using NeoAPTB.ModelsViews;
using NeoAPTB.ModelsMyIntelli;
using Radzen;
using NeoAPTB;
using NeoAPTB.Interfaces;
using NeoAPTB.Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

var rawConn = builder.Configuration.GetConnectionString("MyIntelli");

if (string.IsNullOrWhiteSpace(rawConn))
{
    Console.WriteLine("La cadena de conexión 'MyIntelli' es NULL o está vacía.");
}
else
{
    var csb = new SqlConnectionStringBuilder(rawConn);

    Console.WriteLine($"Servidor: {csb.DataSource}");
    Console.WriteLine($"Base de datos: {csb.InitialCatalog}");
    Console.WriteLine($"Usuario: {csb.UserID}");
    Console.WriteLine($"IntegratedSecurity: {csb.IntegratedSecurity}");

    try
    {
        using var testConn = new SqlConnection(rawConn);
        await testConn.OpenAsync();
        Console.WriteLine("Conexión manual a MyIntelli OK.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Conexión manual a MyIntelli FALLÓ:");
        Console.WriteLine(ex.Message);
    }
}
// =======================================

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddHttpClient();

// Servicios
builder.Services.AddScoped<IPuestosTrabajo, PuestosTrabajoService>();
builder.Services.AddScoped<IMontos, MontosService>();
builder.Services.AddScoped<IResumen, ResumenService>();
builder.Services.AddScoped<IPersonal, PersonalService>();
builder.Services.AddScoped<IMaestraData, MaestraData>();
builder.Services.AddScoped<ITempus, TempusServices>();
builder.Services.AddScoped<IGlobalData, GlobalData>();
builder.Services.AddScoped<ISPIServices, SPIServices>();

// Logics
builder.Services.AddScoped<IRolLogic, RolLogic>();
builder.Services.AddScoped<IRotacionLogic, RotacionLogic>();

// Blazor
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();

// Dbs
builder.Services.AddDbContext<DbNeoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Neo")));

builder.Services.AddDbContext<ViewsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Neo")));

builder.Services.AddDbContext<TempusIiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Tempus")));

builder.Services.AddDbContext<DbSPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SPI")));

builder.Services.AddDbContext<MyIntelliContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyIntelli")));

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
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();