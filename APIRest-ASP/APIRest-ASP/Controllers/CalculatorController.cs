using Microsoft.AspNetCore.Mvc;

namespace APIRest_ASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       
        private readonly ILogger<CalculatorController> _logger;
       

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{numberOne}/{numberTwo}")]
        public IActionResult Sum(string numberOne, string numberTwo)
        {
           return BadRequest("Invalid input");
        }
    }
}
