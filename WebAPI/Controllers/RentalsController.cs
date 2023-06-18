using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Success);
        }
        [HttpGet("get/id")]
        public IActionResult Get(int id)
        {
            var result = _rentalService.GetbyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Success);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Success);
        }
        [HttpPut("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Success);
        }
        [HttpDelete]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }
        [HttpPost("kirala")]
        public IActionResult Kirala(Rental rental)
        {
            var result = _rentalService.Kirala(rental);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Success);
        }
        [HttpPost("teslimet")]
        public IActionResult TeslimEt(Rental rental)
        {
            var result = _rentalService.TeslimEt(rental);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Success);
        }
    }
}
