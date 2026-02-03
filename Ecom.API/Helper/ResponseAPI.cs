using System.Net;
using System.Text.Json;

namespace Ecom.API.Helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageFormStatusCode(StatusCode);
        }
        private string GetMessageFormStatusCode(int statuscode)
        {
            return statuscode switch
            {
                200 => "OK",
                201 => "Created",
                202 => "Accepted",
                204 => "No Content",
                301 => "Moved Permanently",
                302 => "Found",
                304 => "Not Modified",
                307 => "Temporary Redirect",
                308 => "Permanent Redirect",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                405 => "Method Not Allowed",
                408 => "Request Timeout",
                409 => "Conflict",
                410 => "Gone",
                415 => "Unsupported Media Type",
                429 => "Too Many Requests",
                500 => "Internal Server Error",
                501 => "Not Implemented",
                502 => "Bad Gateway",
                503 => "Service Unavailable",
                504 => "Gateway Timeout",
                _ => "Unknown Status Code"
            };
        }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }

}
