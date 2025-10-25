using Backend.Application.DTOs.User;
using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Entities.User.Commands;

public class SignInUserCommand(SignInUserDto dto) : Command<Result<string>>
{
    public SignInUserDto Dto { get; } = dto;
}