using ProgrammingWithDotNetChapterOne.WebApp.Models;
using ProgrammingWithDotNetChapterOne.WebApp.ModelsDTO;
using System;
using System.Collections.Generic;

namespace ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces
{
    public interface IModuleService
    {
        Module GetModuleByName(string moduleName);
        OperationSuccesDTO<List<Module>> GetModules();
        OperationSuccesDTO<Module> AddModule(Module module);
        OperationSuccesDTO<Module> UpdateModule(Module module);
        OperationSuccesDTO<Module> DeleteModule(string name);
    }
}