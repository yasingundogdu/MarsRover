using MarsRover.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.CommandHandlers
{
    public class CalculateFinalPositionCommandHandler : IRequestHandler<CalculateFinalPositionCommand, string>
    {
        public Task<string> Handle(CalculateFinalPositionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
