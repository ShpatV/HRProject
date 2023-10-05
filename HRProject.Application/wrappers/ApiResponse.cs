namespace HRProject.Application.wrappers
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> Success(T data) => new ApiResponse<T> { IsSuccess = true, StatusCode = (int)StatusCodes.OK, Data = data };
        public static ApiResponse<T> Success(string message) => new ApiResponse<T> { IsSuccess = true, StatusCode = (int)StatusCodes.OK, Message = message };
        public static ApiResponse<T> Failure(string error) => new ApiResponse<T> { IsSuccess = false, StatusCode = (int)StatusCodes.BadRequest, Errors = new() { error } };
        public static ApiResponse<T> NotFound(string message) => new ApiResponse<T> { IsSuccess = false, StatusCode = (int)StatusCodes.NotFound, Message = message };
    }

    public class ExceptionResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public ExceptionResponse(List<string> errors )
        {
            Errors = errors;
        }

        public ExceptionResponse(Exception ex)
        {
            Message = ex.Message;
            Errors = new() { ex.InnerException.Message };
        }
    }

    public enum StatusCodes
    {
        OK = 200,
        NotFound = 404,
        BadRequest = 400
    }
}
