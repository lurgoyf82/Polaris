using MediatR;

namespace Polaris.Application.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(string Name, string Email) : IRequest<Guid>;
}
