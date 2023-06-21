using Identity.WebApi.Middlewares;
using Identity.WebApi.ExtensionsMethods;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomAutoMapper();
builder.Services.AddRepositories();
builder.Services.AddMSSQLDbContext(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddMyFluentValidation();

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCustomException();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
