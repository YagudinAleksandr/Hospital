namespace WebApplication1.DTO
{
    /// <summary>
    /// Базовый ответ сервера
    /// </summary>
    public class BaseResponseDTO<T>
    {
        /// <summary>
        /// Статусный код ответа сервера
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Является ли запрос успешным
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Данные
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Ошибки
        /// </summary>
        public string Errors { get; set; }

        public BaseResponseDTO(int statusCode, bool isSuccess, string errors, T data) 
        {
            this.StatusCode = statusCode;
            this.IsSuccess = isSuccess;
            this.Errors = errors;
            this.Data = data;
        }
    }
}
