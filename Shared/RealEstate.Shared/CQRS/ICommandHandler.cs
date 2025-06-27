using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Shared.CQRS;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    
    public Task<JsonResult> Handle(TCommand request, CancellationToken cancellationToken);
    
    
}