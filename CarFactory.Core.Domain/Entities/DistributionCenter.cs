
namespace CarFactory.Core.Domain.Entities
{
    /// <summary>
    /// Represents a distribution center name and location
    /// </summary>
    public class DistributionCenter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

    }
}
