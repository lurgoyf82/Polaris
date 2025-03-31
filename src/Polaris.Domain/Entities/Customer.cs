namespace Polaris.Domain.Entities
{
    /// <summary>
    /// Represents a customer aggregate root.
    /// </summary>
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        // Private constructor for ORM support (if needed)
        private Customer() { }

        public Customer(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            // Raise a domain event upon creation
            var evt = new CustomerCreatedDomainEvent(Id, Name);
            _domainEvents.Add(evt);
        }

        public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
            // Optionally, raise an event to indicate email change.
        }
    }
}
