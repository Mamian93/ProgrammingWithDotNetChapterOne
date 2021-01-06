using ProgrammingWithDotNetChapterOne.WebApp.Data;
using ProgrammingWithDotNetChapterOne.WebApp.Models;
using ProgrammingWithDotNetChapterOne.WebApp.ModelsDTO;
using ProgrammingWithDotNetChapterOne.WebApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingWithDotNetChapterOne.WebApp.Services.Implementations
{
    public class ModuleService : IModuleService
    {
        private readonly CalculatorContext context;

        public ModuleService(CalculatorContext context)
        {
            this.context = context;
        }

        public OperationSuccesDTO<Module> AddModule(Module module)
        {
            context.Module.Add(module);
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public Module GetModuleByName(string moduleName)
        {
            return context.Module.Where(module => module.Name == moduleName).FirstOrDefault();
        }

        public OperationSuccesDTO<List<Module>> GetModules()
        {
            List<Module> modules = context.Module.ToList();

            return new OperationSuccesDTO<List<Module>> { Message = "Success", Result = modules };
        }

        public OperationSuccesDTO<Module> DeleteModule(string name)
        {
            var module = context.Module.Where(m => m.Name == name).FirstOrDefault();
            context.Module.Remove(module);
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationSuccesDTO<Module> UpdateModule(Module module)
        {
            var mod = context.Module.Where(m => m.Name == module.Name).FirstOrDefault();

            mod.Name = module.Name;
            mod.Price = module.Price;
            mod.Weight = module.Weight;
            mod.AssemblyTime = module.AssemblyTime;
            mod.Code = module.Code;
            mod.Description = module.Description;
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Success" };
        }
    }
}