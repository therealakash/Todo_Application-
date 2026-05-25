using System.Threading.Tasks;
using Todo_assginment.custom_exceptions;

namespace Todo_assginment.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException nex)
            {
                context.Response.StatusCode = 404;
               await  context.Response.WriteAsync(nex.Message);

            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }

    }
}
