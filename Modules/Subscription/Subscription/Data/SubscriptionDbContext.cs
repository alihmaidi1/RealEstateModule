using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Subscription.Data;

public class SubscriptionDbContext: DbContext
{
    
    public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options)
        : base(options) { }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        builder.HasDefaultSchema("subscription");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }


}