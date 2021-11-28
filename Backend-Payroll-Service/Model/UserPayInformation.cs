using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Payroll_Service.Model
{
    public class UserPayInformation
    {
        public string CountryCode { get; set; }

        public decimal GrossSalary { get; set; }

        public decimal TaxesDeductions { get; set; }

        public decimal NetSalary { get; set; }
    }
}
