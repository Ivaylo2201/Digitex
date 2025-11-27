using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;

namespace Backend.Infrastructure.Services.Common;

public class PaymentService : IPaymentService
{
    public async Task<Result<string>> CreatePaymentIntentAsync(int userId)
    {
        throw new NotImplementedException();
    }
}