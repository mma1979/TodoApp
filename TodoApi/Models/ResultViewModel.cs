namespace TodoApi.Models;

public class ResultViewModel<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}