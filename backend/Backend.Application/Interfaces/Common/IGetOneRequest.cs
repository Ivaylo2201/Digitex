namespace Backend.Application.Interfaces.Common;

public interface IGetOneRequest
{
    Guid Id { get; init; }
    string Currency { get; init; }
}