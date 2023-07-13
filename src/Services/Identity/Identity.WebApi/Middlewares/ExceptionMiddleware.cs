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
				await HandleExceptionAsync(context, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			HttpStatusCode statusCode;

			switch (exception)
			{
				case BadRequestException:
				{
					statusCode = HttpStatusCode.BadRequest;
					break;
				}
				case NotFoundException:
				{
					statusCode = HttpStatusCode.NotFound;
					break;
				}
				case UnauthorizedException:
				{
					statusCode = HttpStatusCode.Unauthorized;
					break;
				}

				case ForbiddenException:
				{
					statusCode = HttpStatusCode.Forbidden;
					break;
				}
				default:
				{
					statusCode = HttpStatusCode.InternalServerError;
					break;
				}
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
