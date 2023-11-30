using N73HomeTask.Application.Common.Models.Querying;

namespace N73HomeTask.Application.Common.Query.Extensions;

public static class LinqExtension
{
    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source,
        FilterPagination pagination)
    {
        return source.Skip((int)((pagination.PageToken - 1) * pagination.PageSize)).Take((int)pagination.PageSize);
    }

    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source,
        FilterPagination pagination)
    {
        return source.Skip((int)((pagination.PageToken - 1) * pagination.PageSize)).Take((int)pagination.PageSize);
    }
}