using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Shared.CQRS;

public interface IQueryHandler<in TCommand>: IRequestHandler<TCommand> where TCommand : IQuery
{
    
}