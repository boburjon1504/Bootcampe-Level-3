using N73HomeTask.Domain.Common.Exceptions;

namespace N73HomeTask.Domain.Extensions;

public static class ExceptionExtensions
{
    public static async ValueTask<FuncResult<T>> GetValuesAsync<T>(this Func<Task<T>> func) where T : struct
    {
        FuncResult<T> result;
        try
        {
            result = new FuncResult<T>(await func());
        }
        catch (Exception e)
        {
            result = new FuncResult<T>(e);
        }

        return result;
    }
    public static async ValueTask<FuncResult<T>> GetValuesAsync<T>(this Func<ValueTask<T>> func) where T : struct
    {
        FuncResult<T> result;
        try
        {
            result = new FuncResult<T>(await func());
        }
        catch (Exception e)
        {
            result = new FuncResult<T>(e);
        }

        return result;
    }
}