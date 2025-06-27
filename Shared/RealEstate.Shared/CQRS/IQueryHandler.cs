using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Shared.CQRS;

public interface IQueryHandler<in TCommand> where TCommand : IQuery
{
    public Task<JsonResult> Handle(TCommand request, CancellationToken cancellationToken);
    
}