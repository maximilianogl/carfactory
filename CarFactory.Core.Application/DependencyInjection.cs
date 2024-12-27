using CarFactory.Core.Application.DTOs;
using CarFactory.Core.Application.Interfaces;
using CarFactory.Core.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarFactory.Core.Application
{
    public static class DependencyInjection
    {
        public static void RegisterCoreApplication(this IServiceCollection serviceProvider)
        {
            //Register IoC Service class
            serviceProvider.AddTransient<ICarService, CarService>();
            serviceProvider.AddTransient<ISaleService, SaleService>();
            serviceProvider.AddTransient<IDistributionCenterService, DistributionCenterService>();

            //Register fluent validations
            serviceProvider.AddFluentValidationAutoValidation();
            serviceProvider.AddSingleton<IValidator<CreateSaleRequest>, CreateSaleRequestValidator>();


        }

    }
}
