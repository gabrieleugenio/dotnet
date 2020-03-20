﻿using System;
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
        // GET api/values/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public ActionResult<string> sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
               var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber); 
               return Ok(sum.ToString());
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
