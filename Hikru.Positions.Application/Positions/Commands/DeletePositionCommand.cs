using MediatR;

namespace Hikru.Positions.Application.Positions.Commands.Delete;

public class DeletePositionCommand : IRequest<bool>
{
    public string Id { get; }

    public DeletePositionCommand(string id)
    {
        Id = id;
    }
}
