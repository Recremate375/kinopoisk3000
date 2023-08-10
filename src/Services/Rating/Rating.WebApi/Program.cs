using Rating.WebApi.Extensions;
using Rating.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMSSqlDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.ConfigureMassTransit(builder.Configuration);
builder.Services.ConfigreFluentValidation();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureGRPC();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCustomException();
app.UseGRPC();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
