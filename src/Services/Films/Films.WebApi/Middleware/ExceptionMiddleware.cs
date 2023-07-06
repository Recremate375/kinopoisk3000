using Films.Domain.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace Films.WebApi.Middleware
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
