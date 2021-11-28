using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Payroll_Service.BusinessLogic
{
    public class TaxItalyCalculator : ITaxCountryCalucator
    {
        public decimal CalculateDeductionFromSalary(decimal bruttoSalary)
        {
            var tax = this.CalculateTax(bruttoSalary);
            var inps = this.CalculateInps(bruttoSalary);

            return tax + inps;
        }

        private decimal CalculateTax(decimal bruttoSalary)
        {
            return bruttoSalary * 0.25m;
        }

        private decimal CalculateInps(decimal bruttoSalary)
        {
            return bruttoSalary * 0.0919m;
        }
    }
}
