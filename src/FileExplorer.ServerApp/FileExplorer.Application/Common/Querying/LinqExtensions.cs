using FileExplorer.Application.Common.Models.Filtering;

namespace FileExplorer.Application.Common.Querying;

public static class LinqExtensions
{
    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, FilterPagination paginationOptions)
        => source.Skip((paginationOptions.PageToken - 1) * paginationOptions.PageSize).Take(paginationOptions.PageSize);
}