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
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Distrubuted.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]

    public class InputWorkersController : ControllerBase
    {
        private readonly IInputWorkers _inputWorkers;
        private readonly IMapper _mapper;

        public InputWorkersController(IInputWorkers inputWorkers, IMapper mapper)
        {
            _inputWorkers = inputWorkers;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SaveFile([FromBody] JsonElement json)
        {
            try
            {
                _inputWorkers.SaveFile(json.ToString());
                return Ok();
            }
            catch(Exception ex) { return StatusCode(402); }

        }


    }
}
