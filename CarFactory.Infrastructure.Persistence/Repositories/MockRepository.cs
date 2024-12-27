using CarFactory.Core.Domain.Entities;
using CarFactory.Infrastructure.Persistence.Interfaces;

namespace CarFactory.Infrastructure.Persistence.Repositories
{
    // Singleton class for keep database objects in memory
    public class MockRepositoryService : IMockRepositoryService
    {
        public List<Sale> Sales { get; set; }
        public List<Car> Cars { get; set; }
        public List<DistributionCenter> DistributionCenters { get; set; }

        public MockRepositoryService()
        {
            // Create mock data
            Cars = new List<Car>()
            {
                new Car(){
                    Id = new Guid("07DB0B4C-3BD8-48A3-821B-B98F849DF2FE"),
                    BasePrice= 8000,
                    CarModelId =(int)Core.Domain.Enums.CarModel.Sedan
                },
                new Car(){
                    Id = new Guid("6B41AE07-6F66-43EE-9084-21E78AECFCB7"),
                    BasePrice= 9500,
                    CarModelId =(int)Core.Domain.Enums.CarModel.Suv
                },
                new Car(){
                    Id = new Guid("9B15CB4E-A177-4888-AC6E-819F08BE7422"),
                    BasePrice= 12500,
                    CarModelId =(int)Core.Domain.Enums.CarModel.OffRoad
                },
                new Car(){
                    Id = new Guid("7BC1300E-F7C3-4399-AA9F-F841D648C92C"),
                    BasePrice= 18200,
                    CarModelId =(int)Core.Domain.Enums.CarModel.Sport
                },
            };

            DistributionCenters = new List<DistributionCenter>()
            {
                new DistributionCenter()
                {
                    Id = new Guid("74F1A75F-D521-4B43-96C3-C07572025C3E"),
                    Location ="Buenos Aires",
                    Name = "Casa central"
                },
                new DistributionCenter()
                {
                    Id = new Guid("0465B6CD-9D37-4639-B44D-BC94F5E79DDE"),
                    Location ="Rosario, Santa Fe",
                    Name = "Santa Fe"
                },
                new DistributionCenter()
                {
                    Id = new Guid("7BAE3BDD-63EB-4E8B-B507-3ED41DDB4F02"),
                    Location ="San Rafael, Mendoza",
                    Name = "Mendoza"
                },
                new DistributionCenter()
                {
                    Id = new Guid("BE38B77F-1A49-4E2E-B2A6-6BAF9EC63FB9"),
                    Location ="Iguazu, Misiones",
                    Name = "Misiones"
                }

            };

            Sales = new List<Sale>();

            var random = new Random();
            for (int i = 0; i < 50; i++)
            {
                var car = Cars[random.Next(Cars.Count)];
                var center = DistributionCenters[random.Next(DistributionCenters.Count)];
                Sales.Add(new Sale()
                {
                    Id = Guid.NewGuid(),
                    DistributionCenterId = center.Id,
                    DistributionCenter = center,
                    CarId = car.Id,
                    Car = car,
                    SaleDate = DateTime.UtcNow.AddDays(-random.Next(1, 365)),
                });
            }
        }
    }
}
