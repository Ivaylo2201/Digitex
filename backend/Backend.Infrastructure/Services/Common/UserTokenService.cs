using Backend.Application.Interfaces.Services;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Services.Common;

public class UserTokenService(IUserTokenRepository userTokenRepository) : IUserTokenService
{
    public async Task CreateUserTokenAsync()
    {
        throw new NotImplementedException();
    }
}