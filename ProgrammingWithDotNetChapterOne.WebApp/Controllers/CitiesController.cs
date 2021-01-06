using Microsoft.AspNetCore.Mvc;
using ProgrammingWithDotNetChapterOne.WebApp.Models;
using ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces;
using System.Net;

namespace ProgrammingWithDotNetChapterOne.WebApp.Controllers
{
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        [Route("Cities/GetCities")]
        public IActionResult GetCities()
        {
            return Ok(cityService.GetCities().Result);
        }

        [HttpGet]
        [Route("Cities/GetCityByName/{name}")]
        public IActionResult GetCityByName(string name)
        {
            City city = cityService.GetCityByName(name);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPut]
        [Route("Cities/UpdateTransportCost")]
        public IActionResult UpdateTransportCost(City city)
        {
            var response = cityService.UpdateTransportCost(city.Name, city.TransportCost);

            if (response.Message.Equals("Success"))
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPut]
        [Route("Cities/UpdateCostOfWorkingHour")]
        public IActionResult UpdateCostOfWorkingHour(City city)
        {
            var response = cityService.UpdateCostOfWorkingHour(city.Name, city.CostOfWorkingHour);

            if (response.Message.Equals("Success"))
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPost]
        [Route("Cities/AddCity")]
        public IActionResult AddCity(City city)
        {
            if (city == null)
            {
                return BadRequest("Object city is null");
            }

            var response = cityService.AddCity(city);

            if (response.Message.Equals("Success"))
            {
                return Ok(response.Message);
            }

            return BadRequest("Error");
        }

        [HttpDelete]
        [Route("Cities/DeleteCity/{name}")]
        public IActionResult DeleteCity(string name)
        {
            if (name == null)
            {
                return BadRequest("City name is null");
            }

            var response = cityService.DeleteCity(name);

            if (response.Message.Equals("Success"))
            {
                return Ok(response.Message);
            }

            return BadRequest("Error");
        }
    }
}
