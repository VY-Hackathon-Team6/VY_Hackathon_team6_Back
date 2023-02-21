using Amazon.Runtime.Internal.Auth;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Utils
{
    public static class CsvUtils
    {
        public static IEnumerable<OutputGroundHandling> ConvertCsvToJson(string path)
        {
            List<OutputGroundHandling> result = null;

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, new CsvConfiguration(new CultureInfo("es-US")) { HasHeaderRecord = true, Delimiter = ";" }))
            {
                result = csv.GetRecords<OutputGroundHandling>().ToList();
            }

            return result;
        }
    }
}
