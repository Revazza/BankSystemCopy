using System.Net;

namespace BankSystem.Common.Models
{
    public enum HttpResultStatus
    {
        Ok = 0,
        BadRequest = 1,
        Error = 2,
    }

    public class HttpResult
    {
        public string Message { get; set; }
        public HttpResultStatus Status { get; set; }
        public Dictionary<string, object> Payload { get; set; }

        public HttpResult()
        {
            Status = HttpResultStatus.Ok;
            Message = string.Empty;
            Payload = new Dictionary<string, object>();
        }

        public HttpResult(HttpResultStatus status, string message)
        {
            Status = status;
            Message = message;
            Payload = new Dictionary<string, object>();
        }

    }
}
