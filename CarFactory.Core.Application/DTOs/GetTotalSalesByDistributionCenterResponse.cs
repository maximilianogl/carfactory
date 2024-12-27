namespace CarFactory.Core.Application.DTOs
{
    /// <summary>
    /// Response data for get a sales results by distribution center
    /// </summary>
    public class GetTotalSalesByDistributionCenterResponse
    {
        public int TotalSales { get; set; } = 0;
        public decimal TotalProfit { get; set; }
        public string DistributionCenterName { get; set; }
    }
}
