using ProgrammingWithDotNetChapterOne.WebApp.Data;
using ProgrammingWithDotNetChapterOne.WebApp.Models;
using ProgrammingWithDotNetChapterOne.WebApp.ModelsDTO;
using ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingWithDotNetChapterOne.WebApp.Services.Implementations
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly CalculatorContext context;
        private readonly IModuleService moduleService;
        private readonly ICityService cityService;

        public SearchHistoryService(
                CalculatorContext context,
                IModuleService moduleService,
                ICityService cityService)
        {
            this.context = context;
            this.moduleService = moduleService;
            this.cityService = cityService;
        }

        public OperationResultDTO AddSearchHistory(SearchHistory searchHistory)
        {
            context.SearchHistory.Add(searchHistory);
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if (city == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }

            var searchHistoryList = context.SearchHistory.Where(sh => sh.CityId == city.Id);

            if (searchHistoryList == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }
            int counterModule = 0;

            foreach (SearchHistory searchHistory in searchHistoryList)
            {
                counterModule = 0;

                foreach (string searchHistoryPar in moduleListDTO.ModuleList)
                {
                    if (searchHistory.ModuleName1 == searchHistoryPar ||
                         searchHistory.ModuleName2 == searchHistoryPar ||
                         searchHistory.ModuleName3 == searchHistoryPar ||
                         searchHistory.ModuleName4 == searchHistoryPar)
                    {
                        counterModule++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (moduleListDTO.ModuleList.Count() == ModuleHasValue(searchHistory) && moduleListDTO.ModuleList.Count() == counterModule)
                {
                    return new ResultCostDTO { InSearchHistory = true, Cost = searchHistory.ProductionCost };
                }
            }

            return new ResultCostDTO { InSearchHistory = false };
        }

        OperationSuccesDTO<IList<SearchHistory>> ISearchHistoryService.GetSearchHistories()
        {
            List<SearchHistory> searchHistories = context.SearchHistory.ToList();

            return new OperationSuccesDTO<IList<SearchHistory>> { Message = "Success", Result = searchHistories };
        }

        private int ModuleHasValue(SearchHistory SearchHistory)
        {
            int counter = 0;

            if (!(SearchHistory.ModuleName1 == string.Empty))
                counter++;
            if (!(SearchHistory.ModuleName2 == string.Empty))
                counter++;
            if (!(SearchHistory.ModuleName3 == string.Empty))
                counter++;
            if (!(SearchHistory.ModuleName4 == string.Empty))
                counter++;

            return counter;
        }
    }
}