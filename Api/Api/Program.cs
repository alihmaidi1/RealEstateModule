var builder = WebApplication.CreateBuilder(args);

var identityAssembly = typeof(Identity.DependencyInjection).Assembly;
var partnerFinderAssembly = typeof(PartnerFinder.DependencyInjection).Assembly;
var propertyAssembly = typeof(Property.DependencyInjection).Assembly;
var subscriptionAssembly = typeof(Subscription.DependencyInjection).Assembly;

builder.Services.AddOpenApi();
builder.Services.AddCarterWithAssemblies(identityAssembly, partnerFinderAssembly, propertyAssembly, subscriptionAssembly);


builder.Services
    .AddIdentityModule(builder.Configuration)
    .AddPartnerFinderModule(builder.Configuration)
    .AddPropertyModule(builder.Configuration)
    .AddSubscriptionModule(builder.Configuration)
    .AddShared(builder.Configuration,identityAssembly,partnerFinderAssembly,propertyAssembly,subscriptionAssembly);


var app = builder.Build();


app.MapOpenApi();

app.UseSwaggerConfiguration();


app.UseHttpsRedirection();
app.MapCarter();

app.UseIdentityModule()
    .UsePropertyModule()
    .UsePartnerFinderModule()
    .UseSubscriptionModule();


app.Run();

