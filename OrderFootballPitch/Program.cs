using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderFootballPitch.Data;
using OrderFootballPitch.Repository;
using OrderFootballPitch.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext for postgresql
//builder.Services.AddDbContext<PitchOrderDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add DbContext for SQlServer
builder.Services.AddDbContext<PitchOrderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver")).EnableSensitiveDataLogging());

builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                 .AllowAnyHeader()
    )
);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo.Api", Version = "v1", Description = "Api DEMO" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
});
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
