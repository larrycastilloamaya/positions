using Hikru.Positions.Application.Positions.Dtos;
using MediatR;

namespace Hikru.Positions.Application.Positions.Commands.Create;

public class CreatePositionCommand : IRequest<bool>
{
    public PositionCreateDto Dto { get; }

    public CreatePositionCommand(PositionCreateDto dto)
    {
        Dto = dto;
    }
}
