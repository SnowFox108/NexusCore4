using System.Web.Http;
using System.Web.Http.Cors;
using TravelCentreClapham.FlyAfricaDirect.Dal;
using TravelCentreClapham.FlyAfricaDirect.Dal.Models;

namespace TravelCentreClapham.FlyAfricaDirect.WebApi.Controllers
{
    [RoutePrefix("api/ModelBuilder")]
    public class ModelBuilderController : ApiController
    {
        [HttpGet]
        [Route("AfricanWebsiteOffer01")]
        public EnquiryForm01Dto AfricanWebsiteOffer01()
        {
            return new EnquiryForm01Dto()
            {
                PromotionGroupType = PromotionGroupType.AfricanWebsiteOffer01,
            };
        }

        [HttpGet]
        [Route("AfricanWebsiteOffer02")]
        public EnquiryForm01Dto AfricanWebsiteOffer02()
        {
            return new EnquiryForm01Dto()
            {
                PromotionGroupType = PromotionGroupType.AfricanWebsiteOffer01
            };
        }
    }
}
