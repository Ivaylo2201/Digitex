using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IPaymentService
{
    Task<Result<string>> CreatePaymentIntentAsync(int userId);
}