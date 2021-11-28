using Backend_Payroll_Service.BusinessLogic;
using Backend_Payroll_Service.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Backend_Payroll_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollServiceController : ControllerBase
    {
        private static readonly string[] _countryCodes = { "DEU", "ITA", "ESP" };
        private readonly IncomeCalculator _incomeCalculator;

        public PayrollServiceController(
            IncomeCalculator incomeCalculator)
        {
            _incomeCalculator = incomeCalculator;
        }

        [HttpGet("{countryCode}")]
        public ActionResult<UserPayInformation> Get(
            string countryCode,
            [FromQuery]decimal hoursWorked,
            [FromQuery]decimal hourlyRate)
        {
            if (!_countryCodes.Contains(countryCode))
            {
                return BadRequest($"Only {string.Join(", ", _countryCodes)} country codes are supported");
            }
            var bruttoSalary = _incomeCalculator.CalculateGrossIncome(
                hoursWorked,
                hourlyRate);

            decimal taxesDeduction = _incomeCalculator.CalculateTax(
                countryCode,
                hoursWorked,
                hourlyRate);

            return Ok(new UserPayInformation
            {
                CountryCode = countryCode,
                GrossSalary = bruttoSalary,
                TaxesDeductions = taxesDeduction,
                NetSalary = bruttoSalary - taxesDeduction
            });
        }
    }
}
