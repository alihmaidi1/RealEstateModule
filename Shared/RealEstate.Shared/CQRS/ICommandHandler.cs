using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Decorator;

namespace RealEstate.Shared.CQRS;

public interface ICommandHandler<in TCommand>:IRequestHandler<TCommand> where TCommand : ICommand
{
    
    


}