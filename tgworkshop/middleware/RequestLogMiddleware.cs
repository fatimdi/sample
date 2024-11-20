using System.Text;

namespace tgworkshop.middleware;


public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;    

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));        
    }

    public async Task Invoke(HttpContext context)
    {
        var request = context.Request;
        var httpContext = context;
        var originalBodyStream = context.Response.Body;
        try
        {
            var requestBodyStream = new MemoryStream();
            await request.Body.CopyToAsync(requestBodyStream);
            string requestBody = Encoding.UTF8.GetString(requestBodyStream.ToArray());
            var userName = "Tanımsız";

            var headers = request.Headers?.ToDictionary(h => h.Key, h => h.Value);
            string headersJson = System.Text.Json.JsonSerializer.Serialize(headers);

            requestBodyStream.Seek(0, SeekOrigin.Begin);
            request.Body = requestBodyStream;

            //we can save this object in db
            Console.WriteLine($"path: {request.Path}, method: {request.Method}, qString: {request.QueryString.ToString()}, body: {requestBody}, headers: {headersJson}");
            await _next(context);
        }
        catch (Exception)
        {
            throw;
        }

    }
}
