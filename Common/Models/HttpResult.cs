using System.Net;

namespace BankSystem.Common.Models
{
    public enum HttpResultStatus
    {
        Ok = HttpStatusCode.OK,
        InternalServerError = HttpStatusCode.InternalServerError,
        Unauthorized = HttpStatusCode.Unauthorized,
        BadRequest = HttpStatusCode.BadRequest,
    }

    public class HttpResult
    {
        public string Message { get; set; }
        public HttpResultStatus Status { get; set; }

        public Dictionary<string, string> Payload { get; set; }





    }
}
