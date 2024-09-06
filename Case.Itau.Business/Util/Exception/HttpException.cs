namespace Case.Itau.Business.Util.Exception
{
    using System;
    using System.Net;

    public class HttpException : Exception
    {
        public string ExtraData { get; protected set; }
        public HttpStatusCode StatusCode { get; protected set; }
        public int? Code => (int?)StatusCode;

        public HttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public HttpException(HttpStatusCode statusCode, string message, Exception exception) : base(message, exception)
        {
            StatusCode = statusCode;
        }


    }
}
