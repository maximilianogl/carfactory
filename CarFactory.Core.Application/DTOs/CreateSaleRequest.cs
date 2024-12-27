namespace CarFactory.Core.Application.DTOs
{
    /// <summary>
    /// DTO Class for create a new sale
    /// </summary>
    public class CreateSaleRequest
    {
        public Guid CarId { get; set; }
        public Guid DistributionCenterId { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
