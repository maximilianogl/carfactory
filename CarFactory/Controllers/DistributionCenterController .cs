using CarFactory.Core.Application.Interfaces;
using CarFactory.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarFactory.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistributionCenterController : ControllerBase
    {
        private readonly IDistributionCenterService _distributionCenterService;

        public DistributionCenterController(IDistributionCenterService DistributionCenterService)
        {
            _distributionCenterService = DistributionCenterService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DistributionCenter>), 200)]
        public async Task<IActionResult> GetAll()
        {

            var DistributionCenters = await _distributionCenterService.GetAllAsync();
            return Ok(DistributionCenters);
        }
    }
}
