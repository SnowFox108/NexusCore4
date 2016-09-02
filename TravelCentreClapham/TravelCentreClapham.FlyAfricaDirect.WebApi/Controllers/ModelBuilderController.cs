using System.Web.Http;
using System.Web.Http.Cors;
using TravelCentreClapham.FlyAfricaDirect.Dal;
using TravelCentreClapham.FlyAfricaDirect.Dal.Models;

namespace TravelCentreClapham.FlyAfricaDirect.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ModelBuilder")]
    public class ModelBuilderController : ApiController
    {
        [HttpGet]
        [Route("AfricanWebsiteOffer01")]
        public CustomerDto AfricanWebsiteOffer01()
        {
            return new CustomerDto()
            {
                PromotionGroupType = PromotionGroupType.AfricanWebsiteOffer01
            };
        }

        [HttpGet]
        [Route("AfricanWebsiteOffer02")]
        public CustomerDto AfricanWebsiteOffer02()
        {
            return new CustomerDto()
            {
                PromotionGroupType = PromotionGroupType.AfricanWebsiteOffer01
            };
        }
    }
}
