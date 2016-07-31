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
    public class EnquiryController : ApiController
    {
        private readonly IEnquiryFormService _enquiryFormService;

        public EnquiryController(IEnquiryFormService enquiryFormService)
        {
            _enquiryFormService = enquiryFormService;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public bool Post([FromBody]CustomerDto customer)
        {            
            _enquiryFormService.Add(customer);
            return true;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}