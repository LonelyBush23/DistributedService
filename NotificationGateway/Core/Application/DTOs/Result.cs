namespace DistributedService.NotificationGateway.Core.Application.DTOs
{
    public class Result : IResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public int StatusCode { get; private set; }

        private Result(bool success, string message, int statusCode)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }

        // Успешный результат
        public static IResult Ok(string message = "Success")
        {
            return new Result(true, message, 200); // 200 OK
        }

        // Результат ошибки
        public static IResult BadRequest(string message = "Bad Request")
        {
            return new Result(false, message, 400); // 400 Bad Request
        }

        // Ресурс не найден
        public static IResult NotFound(string message = "Not Found")
        {
            return new Result(false, message, 404); // 404 Not Found
        }

        // Ошибка сервера
        public static IResult InternalServerError(string message = "Internal Server Error")
        {
            return new Result(false, message, 500); // 500 Internal Server Error
        }

        // Редирект
        public static IResult Redirect(string url)
        {
            return new Result(true, $"Redirecting to {url}", 302); // 302 Redirect
        }

        public Task ExecuteAsync(HttpContext httpContext)
        {
            throw new NotImplementedException();
        }
    }

}
