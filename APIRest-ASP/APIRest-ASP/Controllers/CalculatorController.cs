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

            if(IsNumeric(numberOne) && IsNumeric(numberTwo)) 
            {
                var sum = ConvertToDecimal(numberOne) + ConvertToDecimal(numberTwo);
                return Ok(sum.ToString());
            }

           return BadRequest("Invalid input");
        }
        
        [HttpGet("sub/{numberOne}/{numberTwo}")]
        public IActionResult sub(string numberOne, string numberTwo)
        {

            if(IsNumeric(numberOne) && IsNumeric(numberTwo)) 
            {
                var sub = ConvertToDecimal(numberOne) - ConvertToDecimal(numberTwo);
                return Ok(sub.ToString());
            }

           return BadRequest("Invalid input");
        }

        [HttpGet("mult/{numberOne}/{numberTwo}")]
        public IActionResult Mult(string numberOne, string numberTwo)
        {

            if (IsNumeric(numberOne) && IsNumeric(numberTwo))
            {
                var mult = ConvertToDecimal(numberOne) * ConvertToDecimal(numberTwo);
                return Ok(mult.ToString());
            }

            return BadRequest("Invalid input");
        }
        
        [HttpGet("div/{numberOne}/{numberTwo}")]
        public IActionResult Div(string numberOne, string numberTwo)
        {

            if (IsNumeric(numberOne) && IsNumeric(numberTwo))
            {
                var div = ConvertToDecimal(numberOne) / ConvertToDecimal(numberTwo);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid input");
        } 
        
        [HttpGet("med/{numberOne}/{numberTwo}")]
        public IActionResult med(string numberOne, string numberTwo)
        {

            if (IsNumeric(numberOne) && IsNumeric(numberTwo))
            {
                var med = (ConvertToDecimal(numberOne) + ConvertToDecimal(numberTwo)) / 2;
                return Ok(med.ToString());
            }

            return BadRequest("Invalid input");
        } 
        
        [HttpGet("raiz/{numberOne}")]
        public IActionResult raiz(string numberOne)
        {

            if (IsNumeric(numberOne))
            {
                var med = Math.Sqrt((double)ConvertToDecimal(numberOne));
                return Ok(med.ToString());
            }

            return BadRequest("Invalid input");
        } 
        
      

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);

            return isNumber;
        }
        
        private int ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
               return (int)decimalValue;
            }
            return 0;
        }

       
    }
}
