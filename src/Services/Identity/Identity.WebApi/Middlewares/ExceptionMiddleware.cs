using System.Net;
using Identity.Domain.Exceptions;
using Newtonsoft.Json;

namespace Identity.Domain.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var statusCode = HttpStatusCode.InternalServerError;

			if (exception is BadRequestException)
			{
				statusCode = HttpStatusCode.BadRequest;
			}
			else if (exception is NotFoundException)
			{
				statusCode = HttpStatusCode.NotFound;
			}
			else if (exception is UnauthorizedException)
			{
				statusCode = HttpStatusCode.Unauthorized;
			}
			else if (exception is ForbiddenException)
			{
				statusCode = HttpStatusCode.Forbidden;
			}

			var response = new { error = exception.Message };
			var jsonResponse = JsonConvert.SerializeObject(response);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)statusCode;
			return context.Response.WriteAsync(jsonResponse);
		}
	}

	public static class ExceptionMiddlewareExtensions
	{
		public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ExceptionMiddleware>();
		}
	}
}
