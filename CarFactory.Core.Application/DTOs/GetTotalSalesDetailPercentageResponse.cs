using CarFactory.Core.Domain.Enums;

namespace CarFactory.Core.Application.DTOs
{
    /// <summary>
    /// Response data for get a sales detail percetage by distribution center and Car Model
    /// </summary>
    public class GetTotalSalesDetailPercentageResponse
    {
        public string DistributionCenterName { get; set; }
        public CarModel CarModel { get; set; }
        public int Percentage { get; set; }
    }
}
