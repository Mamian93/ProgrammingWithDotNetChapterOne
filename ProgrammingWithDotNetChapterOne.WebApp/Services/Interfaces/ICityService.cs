using ProgrammingWithDotNetChapterOne.WebApp.Models;
using ProgrammingWithDotNetChapterOne.WebApp.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces
{
    public interface ICityService
    {
        City GetCityByName(string cityName);
        OperationSuccesDTO<IList<City>> GetCities();
        OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost);
        OperationResultDTO UpdateTransportCost(string cityName, double transportCost);
        OperationResultDTO AddCity(City city);
        OperationResultDTO DeleteCity(string cityName);
    }
}