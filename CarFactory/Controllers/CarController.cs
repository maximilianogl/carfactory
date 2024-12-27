using CarFactory.Core.Application.Interfaces;
using CarFactory.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarFactory.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService CarService)
        {
            _carService = CarService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Car>), 200)]
        public async Task<IActionResult> GetAll()
        {

            var cars = await _carService.GetAllAsync();
            return Ok(cars);
        }
    }
}
