using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/values/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
               var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber); 
               return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        // GET api/values/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public ActionResult<string> subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
               var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber); 
               return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid Input");
        }
        // GET api/values/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public ActionResult<string> division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
               var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber); 
               return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");
        }
        // GET api/values/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public ActionResult<string> multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
               var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber); 
               return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid Input");
        }
        // GET api/values/mean/5/5
        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public ActionResult<string> mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
               var mean = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) / 2; 
               return Ok(mean.ToString());
            }
            return BadRequest("Invalid Input");
        }
        // GET api/values/square-root/5
        [HttpGet("square-root/{number}")]
        public ActionResult<string> squareRoot(string number)
        {
            if (IsNumeric(number))
            {
               var squareRoot = Math.Sqrt((double)ConvertToDecimal(number)); 
               return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }
        private bool IsNumeric(string number){
            double convertNumber;
            bool isNumber = double.TryParse(number,System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo, out convertNumber);
            return isNumber;
        }
        private decimal ConvertToDecimal(string number){
            decimal decimalValue;
            if (decimal.TryParse(number,out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
