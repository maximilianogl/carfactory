using CarFactory.Core.Domain.Enums;

namespace CarFactory.Core.Domain.Entities
{
    /// <summary>
    /// Represents a car with associated model and pricing information.
    /// </summary>
    public class Car
    {
        public Guid Id { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel => (CarModel)CarModelId;
        public decimal BasePrice { get; set; }

        public decimal GetPrice()
        {
            return CarModel == CarModel.Sport ? BasePrice * 1.07M : BasePrice;
        }
    }
}
