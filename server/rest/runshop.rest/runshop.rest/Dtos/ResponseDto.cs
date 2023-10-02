namespace runShop.rest.Dtos
{
    public class ResponseDto<T>
        where T : class
    {
        public string[]? Errors { get; set; }
        public T? Data{ get; set; }
        public ResponseDto(T? data , string[]? errors)
        {
            Errors = errors;
            Data = data;    
        }
        
    }
}
