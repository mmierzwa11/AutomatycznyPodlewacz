using AutomatycznyPodlewacz.Models;
using AutomatycznyPodlewacz.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutomatycznyPodlewacz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly ISystemService _systemService;
        private readonly ILogger<SystemController> _logger;

        public SystemController(ISystemService systemService, ILogger<SystemController> logger)
        {
            _systemService = systemService;
            _logger = logger;
        }

        // GET api/values
        [HttpGet("State")]
        public ActionResult<SystemState> GetState()
        {
            if (!_systemService.IsInitialized)
            {
                return new SystemState();
            }
            return new SystemState(_systemService.IsWatering, _systemService.CurrentTemperature, _systemService.CurrentHumidity);
        }

        [HttpGet("Initialize")]
        public ActionResult<SystemState> GetInitialize()
        {
            if (!_systemService.IsInitialized)
            {
               _systemService.Initialize();
            }
            return new SystemState(_systemService.IsWatering, _systemService.CurrentTemperature, _systemService.CurrentHumidity);
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] int duration)
        {
        }

    }
}
