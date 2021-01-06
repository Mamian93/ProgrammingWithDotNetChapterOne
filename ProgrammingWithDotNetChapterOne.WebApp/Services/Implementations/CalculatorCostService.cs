using ProgrammingWithDotNetChapterOne.WebApp.Data;
using ProgrammingWithDotNetChapterOne.WebApp.ModelsDTO;
using ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces;
using System;

namespace ProgrammingWithDotNetChapterOne.WebApp.Services.Implementations
{
    public class CalculatorCostService : ICalculatorCostService
    {
        private readonly ICityService cityService;
        private readonly IModuleService moduleService;

        public CalculatorCostService(
                ICityService cityService,
                IModuleService moduleService)
        {
            this.cityService = cityService;
            this.moduleService = moduleService;
        }

        OperationResultDTO ICalculatorCostService.CalculateCost(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if (city == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }

            var modulesCost = city.TransportCost;

            foreach (String modulName in moduleListDTO.ModuleList)
            {
                var module = moduleService.GetModuleByName(modulName);

                if (module == null)
                {
                    return new OperationErrorDTO { Code = 404, Message = $"Module with name: {modulName} doesn't exist" };
                }

                modulesCost = modulesCost + module.Price + (module.AssemblyTime * city.CostOfWorkingHour);
            }

            modulesCost = modulesCost * 1.3;

            return new OperationSuccesDTO<ResultCostDTO> { Message = "Success", Result = new ResultCostDTO { Cost = modulesCost, InSearchHistory = false } };
        }
    }
}