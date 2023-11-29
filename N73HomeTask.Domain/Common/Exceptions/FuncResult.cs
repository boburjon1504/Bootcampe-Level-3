namespace N73HomeTask.Domain.Common.Exceptions;

public class FuncResult<T>
{
    public T Data { get; set; }
    public Exception? Exception { get; set; }
    public bool IsSuccess => Exception is null;
    public FuncResult(T data) => Data = data;
    public FuncResult(Exception ex) => Exception = ex;
}