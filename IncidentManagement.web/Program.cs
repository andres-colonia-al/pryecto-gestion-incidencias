using IncidentManagement.Application.Services;
using IncidentManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using IncidentManagement.Infrastructure.Repositories;
using IncidentManagement.Web.Controllers;
using IncidentManagement.web.Controllers.Mapper;

var builder = WebApplication.CreateBuilder(args);

//Configuracion al postgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(connectionString));

//Configuracion de dependencias
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryImp<>));
builder.Services.AddScoped(typeof(ITechnicianRepository), typeof(TechnicianRepositoryImpl));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepositoryImpl));
builder.Services.AddScoped(typeof(IIncidentRepository), typeof(IncidentRepositoryImpl));
builder.Services.AddScoped(typeof(ICommentRepository), typeof(CommentRepositoryImpl));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IncidentService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<TechnicianService>();

builder.Services.AddScoped<CommentMapper>();
builder.Services.AddScoped<TechnicianMapper>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", async context =>
    { context.Response.Redirect("/login.html"); });
});

// configurar rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();