using FluentValidation.AspNetCore;
using Identity.Domain.ExtensionsMethods;
using Identity.Domain.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAutoMapper();
builder.Services.AddRepositories();
builder.Services.AddMSSQLDbContext(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddMyFluentValidation();
builder.Services.AddServices();
builder.Services.ConfigureGRPC(builder.Configuration);

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithAuthentication();

var app = builder.Build();

app.UseCustomException();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
