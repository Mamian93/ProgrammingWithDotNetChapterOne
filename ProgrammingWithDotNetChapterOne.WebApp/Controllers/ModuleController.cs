using Microsoft.AspNetCore.Mvc;
using ProgrammingWithDotNetChapterOne.WebApp.Models;
using ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace ProgrammingWithDotNetChapterOne.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleService moduleService;

        public ModulesController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        [HttpGet]
        [Route("GetModules")]
        public IActionResult GetModules()
        {
            return Ok(moduleService.GetModules().Result);
        }

        [HttpGet]
        [Route("GetModule/{name}")]
        public IActionResult GetModuleByName(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            return Ok(moduleService.GetModuleByName(name));
        }

        [HttpPut]
        [Route("UpdateModule")]
        public IActionResult UpdateModule(Module module)
        {
            return Ok(moduleService.UpdateModule(module).Message);
        }

        [HttpPost]
        [Route("AddModule")]
        public IActionResult AddModule(Module module)
        {
            return Ok(moduleService.AddModule(module).Message);
        }

        [HttpDelete]
        [Route("DeleteModule/{name}")]
        public IActionResult DeleteModule(string name)
        {
            return Ok(moduleService.DeleteModule(name).Message);
        }
    }
}
