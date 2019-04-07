using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    public class Calculator
    {
        [Required]
        public decimal LeftOperand { get; set; }

        [Required]
        public decimal RightOperand { get; set; }

        [Required]
        public string Operator { get; set; }

        public decimal Result { get; set; }

        public Calculator()
        {
            Result = 0;
        }

        public void CalculateResult()
        {
            switch (Operator)
            {
                case "+":
                    Result = LeftOperand + RightOperand;
                    break;
                case "-":
                    Result = LeftOperand - RightOperand;
                    break;
                case "*":
                    Result = LeftOperand * RightOperand;
                    break;
                case "/":
                    if (RightOperand == 0)
                        Result = 0;
                    else
                        Result = LeftOperand / RightOperand;
                    break;
            }
        }

    }
}
