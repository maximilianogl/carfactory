
namespace CarFactory.Core.Application.DTOs
{
    /// <summary>
    /// Response data for get a total sales
    /// </summary>
    public class GetTotalSalesResponse
    {
        public int TotalSales { get; set; } = 0;
        public decimal TotalProfit { get; set; }

    }
}
