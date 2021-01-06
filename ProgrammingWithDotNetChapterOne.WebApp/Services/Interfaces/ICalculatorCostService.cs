using ProgrammingWithDotNetChapterOne.WebApp.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces
{
    public interface ICalculatorCostService
    {
        OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO);
    }
}