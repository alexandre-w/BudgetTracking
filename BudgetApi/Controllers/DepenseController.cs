using AutoMapper;
using BudgetApi.BusinessLayer.Interfaces;
using BudgetApi.BusinessLayer.Models;
using BudgetApi.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BudgetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepenseController : ControllerBase
    {

        private readonly IDepenseService _depenseServices;
        private readonly IMapper _mapper;

        public DepenseController(IMapper mapper, IDepenseService service) {
            _mapper = mapper;
            _depenseServices = service;
        }

        // GET: api/Depense
        [HttpGet]
        public ActionResult<List<DepenseDTO>> Get()
        {

            var depList = _depenseServices.GetAll();
            var listDTO = new List<DepenseDTO>();
            foreach(var dep in depList)
            {
                listDTO.Add(_mapper.Map<DepenseDTO>(dep));
            }
            return listDTO;
        }

        // GET: api/Depense/5
        [HttpGet("{id:length(24)}", Name = "GetDepense")]
        public ActionResult<DepenseDTO> Get(string id)
        {
            var dep = _depenseServices.GetOne(id);
            if (dep == null)
                return NotFound();

            return _mapper.Map<DepenseDTO>(dep);

        } 

        // POST: api/Depense
        [HttpPost]
        public ActionResult<DepenseDTO> Post([FromBody] DepenseDTO depense)
        {
            var dep = _mapper.Map<DepenseBL>(depense);
            _depenseServices.Create(dep);
            return CreatedAtRoute("GetDepense", new { id = depense.Id.ToString() }, depense);

        }

        // PUT: api/Depense/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody] DepenseDTO depense)
        {
            var dep = _depenseServices.GetOne(id);
            if (dep == null)
                return NotFound();

            var depBL = _mapper.Map<DepenseBL>(depense);
            _depenseServices.Update(id, depBL);

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
