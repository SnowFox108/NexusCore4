using NexusCore.Infrastructure.Mappers;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;
using TravelCentreClapham.FlyAfricaDirect.Dal.Models;
using TravelCentreClapham.FlyAfricaDirect.Dal.Repositories;
using System.Transactions;
using TravelCentreClapham.FlyAfricaDirect.Dal;

namespace TravelCentreClapham.FlyAfricaDirect.Main.Services
{
    public class EnquiryFormService : IEnquiryFormService
    {
        private readonly ICustomerRepository _customerRepository;

        public EnquiryFormService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public void Add(EnquiryForm01Dto customer)
        {
            using (var transaction = new TransactionScope())
            {
                customer.Email = customer.Email.ToLower().Trim();
                if (CheckEmailExist(customer.Email, customer.PromotionGroupType))
                {
                    _customerRepository.Insert(customer.MapTo<Customer>());
                    transaction.Complete();
                }
            }
        }

        public bool CheckEmailExist(string email, PromotionGroupType promotionGroupType)
        {
            var result = _customerRepository.GetCustomerByEmail(email, promotionGroupType);
            return (result == null);
        }

        public void OptEmailOut(string email, PromotionGroupType promotionGroupType)
        {
            using (var transaction = new TransactionScope())
            {
                _customerRepository.UpdateCustomerOptStatus(email, promotionGroupType, false);
                transaction.Complete();
            }
        }
    }
}
