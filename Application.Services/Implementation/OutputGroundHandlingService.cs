using Application.Services.Contracts;
using AutoMapper;
using CrossCutting.Utils;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class OutputGroundHandlingService : IOutputGroundHandlingService
    {
        private readonly IMapper _mapper;

        public OutputGroundHandlingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<OutputGroundHandling> GetLastProcessedFile()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("c://processed");

            FileInfo lastFile = directoryInfo.GetFiles().OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
            return CsvUtils.ConvertCsvToJson(lastFile.FullName);            

        }

        public Task<OutputGroundHandling> ProcessFile(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
