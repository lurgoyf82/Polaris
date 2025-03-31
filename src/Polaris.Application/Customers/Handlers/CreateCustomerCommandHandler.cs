using MediatR;
using Polaris.Application.Customers.Commands.CreateCustomer;
using Polaris.Domain.Entities;
using Polaris.Domain.Repositories;

namespace Polaris.Application.Customers.Handlers.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name, request.Email);
            await _customerRepository.AddAsync(customer);
            return customer.Id;
        }
    }
}
