using Films.Application.Hubs;
using Films.WebApi.ExtensionMethods;
using Films.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMyMediatr();
builder.Services.AddRepositories();
builder.Services.AddCustomAutoMapper();
builder.Services.ConfigureMassTransit();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.ConfigureSignalR();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCustomException();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.MapHub<NotificationHub>("/Notification");

app.UseAuthorization();

app.MapControllers();

app.Run();
