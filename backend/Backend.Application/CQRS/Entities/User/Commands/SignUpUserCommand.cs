using Backend.Application.DTOs.User;
using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Entities.User.Commands;

public class SignUpUserCommand(SignUpUserDto dto) : Command<Result<string>>
{
    public SignUpUserDto Dto { get; } = dto;
}