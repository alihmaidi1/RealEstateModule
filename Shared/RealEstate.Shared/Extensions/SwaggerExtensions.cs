using Microsoft.AspNetCore.Builder;

namespace RealEstate.Shared.Extensions;

public static class SwaggerExtensions
{
    
    public static WebApplication UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "");

        });

        return app;
    }
    
}