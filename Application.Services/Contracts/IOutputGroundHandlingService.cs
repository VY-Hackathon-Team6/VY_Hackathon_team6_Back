using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    public interface IOutputGroundHandlingService
    {
        IEnumerable<OutputGroundHandling> GetLastProcessedFile();
        Task<OutputGroundHandling> ProcessFile(IFormFile file);
    }
}
