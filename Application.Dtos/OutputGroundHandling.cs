using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class OutputGroundHandling
    {
            public DateTime Day { get; set; }
            public string Hour { get; set; }
            public string HandlingFunction { get; set; }
            public int FullTimeEmployees { get; set; }
            public int PartTimeEmployees { get; set; }
            public int TotalEmployees { get; set; }
            public Double FullTimeEmployeesCost { get; set; }
            public Double PartTimeEmployeesCost { get; set; }
            public Double TotalCost { get; set; }
    }
}
