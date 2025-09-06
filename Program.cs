using Microsoft.EntityFrameworkCore;
using visionadsmedia.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Register AppDbContext with DI
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers only (no views)
builder.Services.AddControllers();

// ✅ Enable CORS so your separate UI can call this API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();

// Enable CORS
app.UseCors("AllowAll");

// No MVC views, so remove UseEndpoints for views
app.MapControllers();

app.Run();
