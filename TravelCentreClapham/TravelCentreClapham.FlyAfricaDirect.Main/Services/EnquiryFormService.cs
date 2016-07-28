using NexusCore.Infrastructure.Mappers;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;
using TravelCentreClapham.FlyAfricaDirect.Dal.Models;
using TravelCentreClapham.FlyAfricaDirect.Dal.Repositories;
using System.Transactions;

namespace TravelCentreClapham.FlyAfricaDirect.Main.Services
{
    public class EnquiryFormService : IEnquiryFormService
    {
        private readonly ICustomerRepository _customerRepository;

        public EnquiryFormService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public void Add(CustomerDto customer)
        {
            using (var transaction = new TransactionScope())
            {
                _customerRepository.Insert(customer.MapTo<Customer>());
                transaction.Complete();
            }
        }
    }
}
