using Identity.Application.Repositories;
using Identity.Infrastructure.Context;
using Identity.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Configure MSSQL

builder.Services.AddDbContext<IdentityDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection")));

#endregion

#region Add Repositories

builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
