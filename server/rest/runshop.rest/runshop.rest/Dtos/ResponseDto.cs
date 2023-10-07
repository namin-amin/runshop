namespace runShop.rest.Dtos;

public class ResponseSchema<TData>
    where TData : class
{
    public dynamic? Errors { get; set; }
    public TData? Data { get; set; }
    public ResponseSchema(TData? data, dynamic? errors)
    {
        Errors = errors;
        Data = data;
    }

}

