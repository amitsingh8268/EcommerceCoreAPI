namespace EcommerceCoreAPI.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Band Request, You have made",
                401 => "Authorized, You are not",
                404 => "Resource found, It was not",
                500 => "Server Side error",
                _ => "Error",
            };
        }

    }
}
