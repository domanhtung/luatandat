using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnDatApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnDatController : ControllerBase
    {
        private readonly ILogger<AnDatController> _logger;
        public AnDatController(ILogger<AnDatController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("123456");
        }
    }
}