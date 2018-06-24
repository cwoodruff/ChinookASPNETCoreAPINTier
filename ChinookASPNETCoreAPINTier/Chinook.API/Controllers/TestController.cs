using System;
using Microsoft.AspNetCore.Mvc;
using Chinook.API.Configurations;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chinook.API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly AppSettings _appSettings;

        public TestController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_appSettings.TestValue1);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
