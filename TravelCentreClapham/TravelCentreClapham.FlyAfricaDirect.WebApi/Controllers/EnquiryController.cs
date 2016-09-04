using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelCentreClapham.FlyAfricaDirect.Dal.Models;
using TravelCentreClapham.FlyAfricaDirect.Main.Services;

namespace TravelCentreClapham.FlyAfricaDirect.WebApi.Controllers
{
    [RoutePrefix("api/Enquiry")]
    public class EnquiryController : ApiController
    {
        private readonly IEnquiryFormService _enquiryFormService;

        public EnquiryController(IEnquiryFormService enquiryFormService)
        {
            _enquiryFormService = enquiryFormService;
        }

        [HttpPost]
        [Route("AfricanWebsiteOffer01")]
        public bool Post(EnquiryForm01Dto customer)
        {            
            _enquiryFormService.Add(customer);
            return true;
        }
    }
}