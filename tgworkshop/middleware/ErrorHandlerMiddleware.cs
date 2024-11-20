using System.Net;
using System.Text;
using System.Text.Json;
using tgworkshop.models.ErrorHandler;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace tgworkshop.middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            var request = context.Request;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var requestBodyStream = new MemoryStream();
            await request.Body.CopyToAsync(requestBodyStream);
            var requestBody = Encoding.UTF8.GetString(requestBodyStream.ToArray());

            string query = System.Text.Json.JsonSerializer.Serialize(request.QueryString.ToString());

            var exp = new ErrorLog()
            {
                InnerStackTrace = error.InnerException?.StackTrace?.ToString() ?? string.Empty,
                StackTrace = error?.StackTrace ?? string.Empty,
                Path = request?.Path ?? string.Empty,
                Host = request?.Host.Host ?? string.Empty,
                RequestBody = requestBody,
                QueryString = query,
            };
            //we can save this error in db
            switch (error)
            {
                case KeyNotFoundException e:
                    // not found error
                    exp.StatusCode = HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exp.ErrorMessage = error?.Message ?? string.Empty;
                    break;

                default:
                    // unhandled error
                    exp.StatusCode = HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    exp.ErrorMessage = "Server Error, Please contact support team.";
                    break;
            }

            Console.WriteLine(exp.ErrorMessage);
            //var result = JsonSerializer.Serialize(exp);
            await response.WriteAsync(exp.ErrorMessage);
        }
    }
}
