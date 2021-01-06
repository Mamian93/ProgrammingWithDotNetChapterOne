using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingWithDotNetChapterOne.WebApp.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public string ModuleName1 { get; set; }

        public string ModuleName2 { get; set; }

        public string ModuleName3 { get; set; }

        public string ModuleName4 { get; set; }

        public double ProductionCost { get; set; }
    }
}
