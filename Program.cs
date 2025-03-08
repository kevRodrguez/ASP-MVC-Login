using Microsoft.EntityFrameworkCore;
using mvcapp.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container. para ocupar los controladores
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache(); // Requerido para sesiones
builder.Services.AddSession(); // Agregar el servicio de sesión
builder.Services.AddHttpContextAccessor(); // Permite acceder a la sesión en los controladores

//linkear el proyecto con la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyAppContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

app.UseSession(); // Habilita el uso de sesiones en la aplicación

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
