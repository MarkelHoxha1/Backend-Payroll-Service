using Backend_Payroll_Service.BusinessLogic;
using Backend_Payroll_Service.Controllers;
using Backend_Payroll_Service.Model;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Backend_Payroll_Service.Tests
{
    public class Tests
    {
        private PayrollServiceController _payrollServiceController;
        private IncomeCalculator incomeCalculator = new IncomeCalculator();

        [SetUp]
        public void Setup()
        {
            _payrollServiceController = new PayrollServiceController(incomeCalculator);
        }

        [Test]
        public void TestDeu()
        {
           var result = _payrollServiceController.Get("DEU", 35, 35);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestSpain()
        {
            var result = _payrollServiceController.Get("ITA", 10, 25);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestItaly()
        {
            var result = _payrollServiceController.Get("ESP", 30, 15);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase("DEU")]
        [TestCase("ITA")]
        [TestCase("ESP")]
        public void TestCountryIsExecutedCorrect(string countryCode)
        {
            var result = _payrollServiceController.Get(countryCode, 30, 35);


            // Assert
            Assert.AreEqual(countryCode, result.Value.CountryCode);
        }

        [TestCase("DEU", 10, 10, 27)]
        [TestCase("ITA", 10, 10, 34.19)]
        [TestCase("ESP", 10, 10, 36)]
        public void TestCountryIsExecutedCorrectTheTaxCalculator(string countryCode, double hoursWorked, double hourlyRate, double expectedTaxesDecuction)
        {
            var result = _payrollServiceController.Get(countryCode, 30, 35);


            // Assert
            Assert.AreEqual(expectedTaxesDecuction, result.Value.TaxesDeductions);
        }


    }
}