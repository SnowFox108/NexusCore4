using System.Web.Http;
using TravelCentreClapham.FlyAfricaDirect.Dal.Models;

namespace TravelCentreClapham.FlyAfricaDirect.WebApi.Controllers
{
    public class ModelBuilderController : ApiController
    {
        public CustomerDto Customer()
        {
            return new CustomerDto();
        }
    }
}
