namespace TechDaniels.IdentityServer.Domain.Base
{

    public class AppResponse<T>
    {
        public int HttpStatusCode;
        public string Message { get; set; }
        public  T Data {get; set; } 

        public AppResponse(int httpStatusCode, string message)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
        }
        public AppResponse(int httpStatusCode, T data)
        {
            HttpStatusCode = httpStatusCode;
            Data = data;
        }

        public static AppResponse<T> BadRequest(string message) => new(400, message);

        public static AppResponse<T> Unauthorized(string message) => new(401, message);

        public static AppResponse<T> NoContent(string message) => new(204, message);

        public static AppResponse<T> Success(T data) => new(200, data);

        public bool IsSuccess() => HttpStatusCode == 200;

    }
}
