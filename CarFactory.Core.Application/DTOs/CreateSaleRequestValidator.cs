using FluentValidation;

namespace CarFactory.Core.Application.DTOs
{
    /// <summary>
    /// Validation rules for CreateSaleRequest
    /// </summary>
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(m => m.CarId).NotNull().NotEmpty();
            RuleFor(m => m.DistributionCenterId).NotNull().NotEmpty();
            RuleFor(m => m.SaleDate).NotNull().LessThan(DateTime.Now.AddDays(1))
            .WithMessage("The sale date must be in the past.");

        }
    }
}
