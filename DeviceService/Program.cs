using DeviceService.Services;
using DeviceService.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


DeviceAuthorizationService authorizationService = new DeviceAuthorizationService();
DeviceEndpoints deviceEndpoints = new DeviceEndpoints ();
DeviceRegistrationService deviceRegistration = new DeviceRegistrationService();
DeviceRepository deviceRepository = new DeviceRepository();

deviceEndpoints.MapEndpoints(app, authorizationService, deviceRegistration, deviceRepository);


app.Run();
