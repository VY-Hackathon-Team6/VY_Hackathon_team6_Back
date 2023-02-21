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
        [JsonPropertyName("day")]
        public DateTime Day { get; set; }

        [JsonPropertyName("hour")]
        public string Hour { get; set; }

        [JsonPropertyName("handlingFuncion")]
        public string HandlingFunction { get; set; }

        [JsonPropertyName("fullTimeEmployees")]
        public int FullTimeEmployees { get; set; }

        [JsonPropertyName("partTimeEmployees")]
        public int PartTimeEmployees { get; set; }

        [JsonPropertyName("totalEmployees")]
        public int TotalEmployees { get; set; }

        [JsonPropertyName("fullTimeEmployeesCost")]
        public Double FullTimeEmployeesCost { get; set; }

        [JsonPropertyName("partTimeEmployeesCost")]
        public Double PartTimeEmployeesCost { get; set; }

        [JsonPropertyName("totalCost")]
        public Double TotalCost { get; set; }
    }
}