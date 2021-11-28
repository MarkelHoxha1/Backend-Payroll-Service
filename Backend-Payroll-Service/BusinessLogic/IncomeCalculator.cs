using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Payroll_Service.BusinessLogic
{
    public class IncomeCalculator
    {

        public IncomeCalculator()
        {
        }

        public decimal CalculateGrossIncome(decimal hoursWorked, decimal hourlyRate)
        {
            return hoursWorked * hourlyRate;
        }

        public decimal CalculateTax(string countryCode, decimal hoursWorked, decimal hourlyRate)
        {
            decimal bruttoSalary = CalculateGrossIncome(hoursWorked, hourlyRate);

            ITaxCountryCalucator countryCalucator = null;

            switch (countryCode)
            {
                case "ITA":
                    countryCalucator = new TaxItalyCalculator();
                    break;
                case "ESP":
                    countryCalucator = new TaxSpainCalculator();
                    break;
                case "DEU":
                    countryCalucator = new TaxGemanyCalculator();
                    break;
                default:
                    throw new NotImplementedException();
            }

            decimal taxesDeduction = countryCalucator.CalculateDeductionFromSalary(bruttoSalary);

            return taxesDeduction;
        }
    }
}
