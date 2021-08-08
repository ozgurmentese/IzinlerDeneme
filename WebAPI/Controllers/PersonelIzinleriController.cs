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
    public class PersonelIzinleriController : ControllerBase
    {
        IPersonelIzinService _personelIzinService;

        public PersonelIzinleriController(IPersonelIzinService personelIzinService)
        {
            _personelIzinService = personelIzinService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _personelIzinService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelIzin personelIzin)
        {
            var result = _personelIzinService.Add(personelIzin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelIzin personelIzin)
        {
            var result = _personelIzinService.Update(personelIzin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getpersoneller")]
        public IActionResult GetPersoneller()
        {
            var result = _personelIzinService.GetPersonelller();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _personelIzinService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
