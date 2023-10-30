using Application;
using AspNetCoreRateLimit;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Serilog;
using WebApi;
using WebApi.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddMapperServices();
builder.Services.AddSignalRServices();

var appDataFolder = Path.Combine(builder.Environment.ContentRootPath, "Database");
AppDomain.CurrentDomain.SetData("DataDirectory", appDataFolder);

<<<<<<< Updated upstream
=======
// CORS
>>>>>>> Stashed changes
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()
));

// Version
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Clean-Architecture-WebApi", Version = "v2" });
});

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(2, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

// HTTP Request Limit
builder.Services.AddOptions();
builder.Services.AddMemoryCache();
builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting"));
builder.Services.Configure<ClientRateLimitPolicies>(builder.Configuration.GetSection("ClientRateLimitPolicies"));
builder.Services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

// MiniProfiler Settings
builder.Services.AddMiniProfiler(options =>
{
    options.RouteBasePath = "/profiler"; 
}).AddEntityFramework();


// Serilog Using
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.File("logs.txt")
    .CreateLogger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Serilog Server Error Logs
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // Version 2.0 start configuration
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Clean-Architecture-WebApi v2");
    });
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseStaticFiles();

app.UseCors();

<<<<<<< Updated upstream
=======
// MiniProfiler Usage
app.UseMiniProfiler();  

>>>>>>> Stashed changes
app.UseAuthorization();

app.MapControllers();

<<<<<<< Updated upstream
=======
// SignalR Hubs Configuration
>>>>>>> Stashed changes
app.MapHubs();

app.Run();
