using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.CQRS;
using RealEstate.Shared.OperationResult;

namespace Subscription.Features.Test;

public record CreateProductCommand(string Name):ICommand;

public class CreateProductValidation: AbstractValidator<CreateProductCommand>
{
    public CreateProductValidation()
    {

        RuleFor(x => x.Name)
            .NotNull();
    }
    
    
}

public class TestCommandHandler: ICommandHandler<CreateProductCommand>
{
    
    public async Task<JsonResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        return new JsonResult("sdfsdf");
    }
}