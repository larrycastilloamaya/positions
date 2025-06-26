using Hikru.Positions.Application.Positions.Dtos;
using MediatR;

namespace Hikru.Positions.Application.Positions.Commands.Update;

public class UpdatePositionCommand : IRequest<bool>
{
    public UpdatePositionDto Dto { get; }

    public UpdatePositionCommand(UpdatePositionDto dto)
    {
        Dto = dto;
    }
}
