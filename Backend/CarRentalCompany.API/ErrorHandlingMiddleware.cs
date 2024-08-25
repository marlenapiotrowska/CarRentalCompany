using CarRentalCompany.Application.Exceptions;
using CarRentalCompany.Infrastructure.Exceptions;

namespace CarRentalCompany.API
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch (Exception ex)
			{
                context.Response.ContentType = "application/text/plain";

                switch (ex)
				{
                    case EntityNotFoundException:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsync(ex.Message);
                        break;

                    case EmptyInputValueException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync(ex.Message);
                        break;

                    case InvalidValueException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync(ex.Message);
                        break;

                    case InvalidProcedureException:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsync(ex.Message);
                        break;

                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsync(ex.Message);
                        break;
                }
			}
        }
    }
}
