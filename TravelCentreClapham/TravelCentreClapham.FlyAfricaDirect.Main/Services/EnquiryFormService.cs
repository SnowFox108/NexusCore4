using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCentreClapham.FlyAfricaDirect.Dal.Repositories;

namespace TravelCentreClapham.FlyAfricaDirect.Main.Services
{
    public class EnquiryFormService
    {
        private readonly ICustomerRepository _customerRepository;

        public EnquiryFormService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


    }
}
