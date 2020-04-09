using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static readonly List<string> _Values = Enumerable.Range(1, 10).Select(i => $"Values {i}").ToList();

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _Values;
        }

        [HttpGet("{Id}")]
        public ActionResult<string> Get(int Id)
        {
            if (Id < 0)
                return BadRequest();
            if (Id > _Values.Count)
                return NotFound();
            return _Values[Id];
        }

        [HttpPost]
        public void Post(string value) => _Values.Add(value);

        [HttpPut("{id}")]
        public ActionResult Put(int Id, string value)
        {
            if (Id < 0 || Id >= _Values.Count)
                return BadRequest();
            _Values[Id] = value;
            return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete (int Id)
        {
            if (Id < 0 || Id >= _Values.Count)
                return BadRequest();
            _Values.RemoveAt(Id);
            return Ok();
        }
    }
}