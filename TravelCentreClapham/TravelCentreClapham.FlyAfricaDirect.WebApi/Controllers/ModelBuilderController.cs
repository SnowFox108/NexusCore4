using System.Web.Http;
using TravelCentreClapham.FlyAfricaDirect.Dal;
using TravelCentreClapham.FlyAfricaDirect.Dal.Models;

namespace TravelCentreClapham.FlyAfricaDirect.WebApi.Controllers
{
    public class ModelBuilderController : ApiController
    {
        public CustomerDto AfricanWebsiteOffer01()
        {
            return new CustomerDto()
            {
                PromotionGroupType = PromotionGroupType.AfricanWebsiteOffer01
            };
        }
    }
}
