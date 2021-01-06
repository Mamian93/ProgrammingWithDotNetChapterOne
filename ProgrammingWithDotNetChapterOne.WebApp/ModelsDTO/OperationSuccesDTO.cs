using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingWithDotNetChapterOne.WebApp.ModelsDTO
{
    public class OperationSuccesDTO<T> : OperationResultDTO
        where T : class
    {
        public T Result { get; set; }
    }
}