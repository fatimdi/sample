using System.Net;

namespace tgworkshop.models.ErrorHandler;
public class ErrorLog
{    
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public string StackTrace { get; set; }
    public string InnerStackTrace { get; set; }
    public string ErrorMessage { get; set; }
    public string Path { get; set; }
    public string Host { get; set; }
    public string RequestBody { get; set; }
    public string QueryString { get; set; }

    public HttpStatusCode StatusCode { get; set; }
}