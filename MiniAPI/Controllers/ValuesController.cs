using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniAPI.Definitions.Services;
using System.Collections.Generic;

namespace MiniAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class ValuesController : BaseController<IValuesService>
    {
        public ValuesController(IValuesService service) : base(service)
        {

        }

        // GET api/values
        [HttpGet]
        [Route("value")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return service.GetAll();
        }

        // GET api/values/5
        [HttpGet]
        [Route("value/{id}")]
        public ActionResult<string> Get([FromRoute] int id)
        {
            return service.Get(id);
        }

        // POST api/values
        [HttpPost]
        [Route("value")]
        public void Post([FromBody] string value)
        {
            service.Post(value);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("value/{id}")]
        public void Put(int id, [FromBody] string value)
        {
            service.Put(id, value);
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("value/{id}")]
        public void Delete([FromRoute] int id)
        {
            service.Delete(id);
        }
    }
}
