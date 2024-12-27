using CarFactory.Core.Application.DTOs;
using CarFactory.Core.Application.Exceptions;
using CarFactory.Core.Application.Interfaces;
using CarFactory.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Profiling;

namespace CarFactory.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request)
        {
            try
            {
                var sale = await _saleService.CreateSaleAsync(request);
                return Created("", sale);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Sale>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _saleService.GetAllAsync();
            return Ok(sales);
        }
        /// <summary>
        /// Return the total sales volume
        /// </summary>
        /// <returns>Total sales and profit</returns>
        [HttpGet("TotalSales")]
        [ProducesResponseType(typeof(GetTotalSalesResponse), 200)]
        public async Task<IActionResult> GetTotalSales()
        {
            var sales = await _saleService.GetTotalSalesAsync();
            return Ok(sales);
        }
        /// <summary>
        /// Returns the sales volume by distribution center 
        /// </summary>
        /// <returns></returns>
        [HttpGet("TotalSalesByDistributionCenter")]
        [ProducesResponseType(typeof(GetTotalSalesByDistributionCenterResponse), 200)]
        public async Task<IActionResult> GetTotalSalesByDistributionCenter()
        {
            var sales = await _saleService.GetTotalSalesByDistributionCenter();
            return Ok(sales);
        }
        /// <summary>
        /// Returns the percentage of units of each model sold in each center out of the company's total sales.
        /// </summary>
        /// <returns></returns>
        [HttpGet("TotalSalesDetailPercentage")]
        [ProducesResponseType(typeof(GetTotalSalesDetailPercentageResponse), 200)]
        public async Task<IActionResult> GetTotalSalesDetailPercentage()
        {

            var sales = await _saleService.GetTotalSalesDetailPercentage();
            return Ok(sales);
        }
    }
}
