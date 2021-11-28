using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Payroll_Service.BusinessLogic
{
    public class TaxSpainCalculator : ITaxCountryCalucator
    {
        public decimal CalculateDeductionFromSalary(decimal bruttoSalary)
        {
            var tax = this.CalculateSpainTax(bruttoSalary);
            var socialCharge = this.CalculateSpainSocialCharge(bruttoSalary);
            var pensionContribution = this.CalculateSpainPensionContribution(bruttoSalary);

            return tax + socialCharge + pensionContribution;
        }
        private decimal CalculateSpainTax(decimal bruttoSalary)
        {
            if (bruttoSalary <= 600)
            {
                return bruttoSalary * 0.25m;
            }
            return 600 * 0.25m + (bruttoSalary - 600) * 0.4m;
        }

        private decimal CalculateSpainSocialCharge(decimal bruttoSalary)
        {
            if (bruttoSalary <= 500)
            {
                return bruttoSalary * 0.07m;
            }
            return (500 * 0.07m) + ((bruttoSalary - 500) * 0.08m);
        }

        private decimal CalculateSpainPensionContribution(decimal bruttoSalary)
        {
            return bruttoSalary * 0.04m;
        }
    }
}
