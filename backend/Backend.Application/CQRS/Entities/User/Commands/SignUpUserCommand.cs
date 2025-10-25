using Backend.Application.DTOs;
using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.User.Commands;

public class SignUpUserCommand(SignUpUserDto dto) : Command<Result<string>>
{
    public SignUpUserDto Dto { get; } = dto;
}