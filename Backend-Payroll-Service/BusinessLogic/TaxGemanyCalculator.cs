using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Payroll_Service.BusinessLogic
{
    public class TaxGemanyCalculator : ITaxCountryCalucator
    {
        public decimal CalculateDeductionFromSalary(decimal bruttoSalary)
        {
            var tax = this.CalculateTax(bruttoSalary);
            var pensionContribution = this.CalculatePensionContribution(bruttoSalary);

            return tax + pensionContribution;
        }

        private decimal CalculateTax(decimal grossIncome)
        {
            if (grossIncome <= 400)
            {
                return grossIncome * 0.25m;
            }
            return 400 * 0.25m + (grossIncome - 400) * 0.32m;
        }

        private decimal CalculatePensionContribution(decimal grossIncome)
        {
            return grossIncome * 0.02m;
        }
    }
}
