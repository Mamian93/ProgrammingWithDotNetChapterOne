using Microsoft.AspNetCore.Mvc;
using ProgrammingWithDotNetChapterOne.WebApp.Models;
using ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace ProgrammingWithDotNetChapterOne.WebApp.Controllers
{
    [ApiController]
    public class SearchHistoriesController : ControllerBase
    {
        private readonly ISearchHistoryService searchHistoryService;

        public SearchHistoriesController(ISearchHistoryService searchHistoryService)
        {
            this.searchHistoryService = searchHistoryService;
        }

        [HttpGet]
        [Route("SearchHistories/GetSearchHistory")]
        public IActionResult GetSearchHistory()
        {
            return Ok(searchHistoryService.GetSearchHistories().Result);
        }

        [HttpPost]
        [Route("SearchHistories/AddSearchHistory")]
        public IActionResult AddSearchHistory(SearchHistory searchHistory)
        {
            if (searchHistory == null)
            {
                return BadRequest("Object searchHistory is null");
            }

            var response = searchHistoryService.AddSearchHistory(searchHistory);

            if (response.Message.Equals("Success"))
            {
                return Ok("Success");
            }

            return BadRequest("Error");
        }
    }
}
