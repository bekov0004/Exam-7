using System.Net;

namespace Domain.Wrapper;

public class Response<T>
{
    public T Date { get; set; }
    public List<string> Errors { get; set; }
    public int StatusCode { get; set; }

    public Response(T date)
    {
        Date = date;
        Errors = new List<string>();
        StatusCode = 200;
    }

    public Response(HttpStatusCode statusCode, List<string> errors)
    {
        Errors = errors;
        StatusCode = (int)statusCode;
    }
}