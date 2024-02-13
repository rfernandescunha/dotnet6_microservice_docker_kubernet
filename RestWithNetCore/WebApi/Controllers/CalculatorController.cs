using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}", Name = "Sum")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(value);
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}", Name = "Sutraction")]
        public IActionResult Sutraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(value);
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}", Name = "Division")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(value);
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}", Name = "Multiplication")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(value);
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("Mean/{firstNumber}/{secondNumber}", Name = "Mean")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var value = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

                return Ok(value);
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("SquareRoot/{number}", Name = "SquareRoot")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var value = Math.Sqrt((double)ConvertToDecimal(number));

                return Ok(value);
            }

            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
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
    }
}
