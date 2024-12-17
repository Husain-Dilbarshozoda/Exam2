using System.Net;

namespace Infastructure;

public class Response<T>
{
    public T? Data { get; set; }
    public int HttpStatuscode { get; set; }
    public string Messenge { get; set; }

    public Response(T data)
    {
        Data = data;
        HttpStatuscode = 200;
        Messenge = "";
    }

    public Response(HttpStatusCode statusCode, string messenge)
    {
        HttpStatuscode = (int)statusCode;
        Messenge = messenge;
    }
    
}