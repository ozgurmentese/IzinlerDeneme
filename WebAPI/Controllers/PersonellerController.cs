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
    public class PersonellerController : ControllerBase
    {
        IPersonelService _personelService;

        public PersonellerController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [HttpPost("add")]
        public IActionResult Add(Personel personel)
        {
            var result = _personelService.Add(personel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _personelService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("izinver")]
        public IActionResult IzinVer(Personel personel,[FromForm]Zamanlar zamanlar)
        {
            var result = _personelService.IzinVer(personel, zamanlar);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
