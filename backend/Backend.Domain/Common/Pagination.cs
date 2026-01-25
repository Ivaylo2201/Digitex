namespace Backend.Domain.Common;

public record Pagination<TItem>
{
    public required IEnumerable<TItem> Items { get; init; }
    public required int TotalItems { get; init; }
    public required int TotalPages { get; init; }
}