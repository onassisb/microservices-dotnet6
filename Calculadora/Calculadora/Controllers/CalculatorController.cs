using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controllers
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

        [HttpGet("sum/{firstNumber}/{SecondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("substraction/{firstNumber}/{SecondNumber}")]
        public IActionResult Substraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("division/{firstNumber}/{SecondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("multiplication/{firstNumber}/{SecondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("mean/{firstNumber}/{SecondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber) )
            {
                var result = Math.Sqrt((double) ConvertToDecimal(firstNumber));
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}