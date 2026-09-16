using DeviceService.Data;
using DeviceService.Services;
using DeviceService.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DeviceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DeviceDatabase")));

builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddSingleton<DeviceAuthorizationService>();
builder.Services.AddSingleton<DeviceRegistrationService>();
builder.Services.AddSingleton<DeviceEndpoints>();

var app = builder.Build();

var deviceEndpoints = app.Services.GetRequiredService<DeviceEndpoints>();
deviceEndpoints.MapEndpoints(app);

app.Run();
