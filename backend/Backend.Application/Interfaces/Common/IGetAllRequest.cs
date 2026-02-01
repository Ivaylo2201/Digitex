namespace Backend.Application.Interfaces.Common;

public interface IGetAllRequest
{
    int Page { get; init; }
    int PageSize { get; init; }
    string Currency { get; init; }
    IDictionary<string, string> Criteria { get; init; }
}