using ContactsLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ICitiesRepo _citiesRepository;
        public CitiesController(ICitiesRepo citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cities = _citiesRepository.GetCities();
            if (cities == null)             
               return NotFound();
             
          return Ok(cities);
            
        }
    }
}
