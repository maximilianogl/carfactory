namespace CarFactory.Core.Domain.Entities
{
    /// <summary>
    /// Represents a sale transaction, including details about the car sold, 
    /// the distribution center where the sale occurred, and the total price.
    /// </summary>
    public class Sale
    {
        public Guid Id { get; set; }
        public Guid DistributionCenterId { get; set; }
        public DistributionCenter DistributionCenter { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public DateTime SaleDate { get; set; }

        public decimal TotalPrice => Car.GetPrice();
    }
}
