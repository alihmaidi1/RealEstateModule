namespace RealEstate.Shared.CQRS;

public interface IDomainEvent
{
    public Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn=> DateTime.UtcNow;
    public string EventType => GetType().AssemblyQualifiedName!;
}