using Application.Dtos;
using Application.Services.Contracts;
using AutoMapper;
using CrossCutting.Utils;
using Distrubuted.WebAPI.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Distrubuted.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]

    public class OutputGroundHandlingController : ControllerBase
    {
        private readonly IOutputGroundHandlingService _outputGroundHandlingService;
        private readonly IMapper _mapper;

        public OutputGroundHandlingController(IOutputGroundHandlingService outputGroundHandlingService, IMapper mapper)
        {
            _outputGroundHandlingService = outputGroundHandlingService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = _outputGroundHandlingService.GetLastProcessedFile();

            return Ok(result);
        }


    }
}
