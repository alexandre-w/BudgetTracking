using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApi.Models;
using BudgetApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepenseController : ControllerBase
    {

        private readonly DepenseServices _depenseServices;

        public DepenseController(DepenseServices service) {
            _depenseServices = service;
        }

        // GET: api/Depense
        [HttpGet]
        public ActionResult<List<Depense>> Get()
        {
            return _depenseServices.GetAll();
        }

        // GET: api/Depense/5
        [HttpGet("{id:length(24)}", Name = "GetDepense")]
        public ActionResult<Depense> Get(string id)
        {
            var dep = _depenseServices.GetOne(id);
            if (dep == null)
                return NotFound();

            return dep;
        } 

        // POST: api/Depense
        [HttpPost]
        public ActionResult<Depense> Post([FromBody] Depense depense)
        { 
            _depenseServices.Create(depense);
            return CreatedAtRoute("GetDepense", new { id = depense.Id.ToString() }, depense);

        }

        // PUT: api/Depense/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody] Depense depense)
        {
            var dep = _depenseServices.GetOne(id);
            if (dep == null)
                return NotFound();

            _depenseServices.Update(id, depense);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var dep = _depenseServices.GetOne(id);

            if (dep == null)
                return NotFound();

            _depenseServices.Delete(dep.Id);

            return NoContent();
        }
    }
}
