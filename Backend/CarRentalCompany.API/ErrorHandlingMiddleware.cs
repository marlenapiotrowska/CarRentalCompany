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
				switch (ex)
				{
                    case EntityNotFoundException:
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync(ex.Message);
                        break;

                    case EmptyInputValueException:
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync(ex.Message);
                        break;

                    case InvalidValueException:
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync(ex.Message);
                        break;

                    default:
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync(ex.Message);
                        break;
                }
			}
        }
    }
}
