namespace Backend.Domain.Common;

public record PaginatedResponse<T>
{
    public required T Items { get; init; }
    public required int TotalItems { get; init; }
    public required int TotalPages { get; init; }
}