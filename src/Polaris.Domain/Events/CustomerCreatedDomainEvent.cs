namespace Polaris.Domain.Events
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }

    public sealed record CustomerCreatedDomainEvent(Guid CustomerId, string Name) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
