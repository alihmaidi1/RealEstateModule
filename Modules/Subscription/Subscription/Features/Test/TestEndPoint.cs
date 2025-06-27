using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using RealEstate.Shared.CQRS;

namespace Subscription.Features.Test;

public class TestEndPoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductCommand request,ICommandHandler<CreateProductCommand> handler,CancellationToken cancellation) =>
            {
                // var command = request.Adapt<CreateProductCommand>();
        
                // var result = await sender.Send(command);
        
                // var response = result.Adapt<CreateProductResponse>();
                return handler.Handle(request, cancellation); 
                // return Results.Created($"/products/{response.Id}", response);
            })
            .WithName("CreateProduct")
            .Produces<string>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
    }
}