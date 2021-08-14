using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelRaporlariController : ControllerBase
    {
        readonly IPersonelRaporService _personelRaporService;

        public PersonelRaporlariController(IPersonelRaporService personelRaporService)
        {
            _personelRaporService = personelRaporService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _personelRaporService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelRapor personelRapor)
        {
            var result = _personelRaporService.Add(personelRapor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelRapor personelRapor)
        {
            var result = _personelRaporService.Update(personelRapor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getpersoneller")]
        public IActionResult GetPersoneller()
        {
            var result = _personelRaporService.GetPersonelller();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _personelRaporService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
