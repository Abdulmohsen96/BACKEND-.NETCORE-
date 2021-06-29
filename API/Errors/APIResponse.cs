using System;

namespace API.Errors {
    public class APIResponse {
        public APIResponse(int statusCode, string message = null) {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode) {
            return statusCode switch {
                400 => "A bad request have been made",
                401 => "You are not Authorized",
                404 => "No resource was found",
                500 => "Internal server error. FATAL",
                _ => null
            };
        }
    }
}