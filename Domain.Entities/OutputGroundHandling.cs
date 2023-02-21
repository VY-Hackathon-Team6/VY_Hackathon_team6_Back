using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OutputGroundHandling
    {
        public DateTime Day { get; set; }

        public string Hour { get; set; }

        [JsonPropertyName("handling_function")]
        public string HandlingFunction { get; set; }

        [JsonPropertyName("full-time_employees")]
        public int FullTimeEmployees { get; set; }

        [JsonPropertyName("part-time_employees")]
        public int PartTimeEmployees { get; set; }

        [JsonPropertyName("total_employees")]
        public int TotalEmployees { get; set; }

        [JsonPropertyName("full-time_employees_cost")]
        public Double FullTimeEmployeesCost { get; set; }

        [JsonPropertyName("part-time_employees_cost")]
        public Double PartTimeEmployeesCost { get; set; }

        [JsonPropertyName("total_cost")]
        public Double TotalCost { get; set; }
    }
}