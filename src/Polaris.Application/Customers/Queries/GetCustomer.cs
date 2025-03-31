using MediatR;
using Polaris.Application.Customers.DTOs.Queries;

namespace Polaris.Application.Customers.Queries.GetCustomer
{
    public record GetCustomerQuery(Guid CustomerId) : IRequest<GetCustomerDto>;

}
