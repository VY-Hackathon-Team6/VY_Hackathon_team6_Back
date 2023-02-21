using Application.Services.Contracts;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class InputWorkers : IInputWorkers
    {
        public void SaveFile(JObject json)
        {
            var path = $"c://raw//{DateTime.Now.ToString("yyyyMMdd-HHmmss")}.json";
            File.WriteAllText(path, json.ToString());
        }
    }
}
