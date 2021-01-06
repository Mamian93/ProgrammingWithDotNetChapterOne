using ProgrammingWithDotNetChapterOne.WebApp.Data;
using ProgrammingWithDotNetChapterOne.WebApp.Models;
using ProgrammingWithDotNetChapterOne.WebApp.ModelsDTO;
using ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingWithDotNetChapterOne.WebApp.Services.Implementations
{
    public class CityService : ICityService
    {
        private readonly CalculatorContext context;

        public CityService(CalculatorContext context)
        {
            this.context = context;
        }

        public City GetCityByName(string cityName)
        {
            return context.City.Where(city => city.Name == cityName).FirstOrDefault();
        }

        public OperationResultDTO UpdateTransportCost(string cityName, double transportCost)
        {
            var updateCity = context.City.Where(city => city.Name == cityName).FirstOrDefault();

            if (updateCity == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }

            updateCity.TransportCost = transportCost;
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost)
        {
            var updateCity = context.City.Where(city => city.Name == cityName).FirstOrDefault();

            if (updateCity == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }

            updateCity.CostOfWorkingHour = workingHourCost;
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationSuccesDTO<IList<City>> GetCities()
        {
            List<City> cities = context.City.ToList();

            return new OperationSuccesDTO<IList<City>> { Message = "Success", Result = cities };
        }

        public OperationResultDTO AddCity(City city)
        {
            context.City.Add(city);
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationResultDTO DeleteCity(string cityName)
        {
            var city = GetCityByName(cityName);

            if (city == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }

            context.City.Remove(city);
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Success" };
        }
    }
}