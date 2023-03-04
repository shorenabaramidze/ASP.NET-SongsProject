using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Homework1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet]
        [Route("api/values/getformatters")]
        public IEnumerable<string> GetFormatters()
        {
            List<string> formatters = new List<string>();
            foreach (var item in GlobalConfiguration.Configuration.Formatters)
            {
                formatters.Add(item.ToString());
            }
            return formatters.AsEnumerable<string>();
        }


        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
