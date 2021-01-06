using Microsoft.AspNetCore.Mvc;
using ProgrammingWithDotNetChapterOne.WebApp.ModelsDTO;
using ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces;

namespace ProgrammingWithDotNetChapterOne.WebApp.Controllers
{
    [ApiController]
    public class ShowResultController : ControllerBase
    {
        private readonly IShowResultService showResultService;

        public ShowResultController(IShowResultService showResultService)
        {
            this.showResultService = showResultService;
        }

        [HttpPost]
        [Route("ShowResult/Get")]
        public IActionResult GetCost(ShowResultDTO showResultDTO)
        {
            var result = this.showResultService.PresentResult(showResultDTO.CityName, showResultDTO.ModuleListDTO);

            if (result.Cost == -1)
            {
                return StatusCode(417, "Error, propably bad module name");
            }
            return Ok(this.showResultService.PresentResult(showResultDTO.CityName, showResultDTO.ModuleListDTO));
        }
    }
}
