using Backend.Application.DTOs;
using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.User.Commands;

public class SignInUserCommand(SignInUserDto dto) : Command<Result<string>>
{
    public SignInUserDto Dto { get; } = dto;
}