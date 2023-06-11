using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _brandService.GetAll();
            if(result.success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(i=> i.Id == id);
            if (result.success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("add")]
        
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if(result.success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            if( result.success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete (Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


    }
}
