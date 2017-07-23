using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollGenerator.Helper
{
    public class IncomeTaxHelper
    {
        protected virtual int CaclulateIncomeTax()
        {
            int incomeTax = 0;

            var taxcases = new Dictionary<Func<int, bool>, Func<int, int>>
            {
                {
                    salary => salary>= 0 && salary<=18200, x=> incomeTax = 0
                },
                {
                    salary => salary>= 18201 && salary<=37000, x => incomeTax = Tax2(AnnualSalary)
                },
                {
                    salary => salary>=37001 && salary<=80000, x => incomeTax = Tax3(AnnualSalary)
                },
                {
                    salary => salary>=80001 && salary<=180000, x=> incomeTax = Tax4(AnnualSalary)
                },
                {
                    salary => salary>180001, x=> incomeTax = Tax5(x)
                }
            };

            (taxcases.First(x => x.Key(AnnualSalary))).Value.Invoke(AnnualSalary);
            return incomeTax;
        }

        private int Tax2(int annualSalary)
        {
            var tax = ((annualSalary - 18200) * 0.19) / 12;
            return Convert.ToInt32(Math.Round(tax, MidpointRounding.AwayFromZero));
        }

        private int Tax3(int annualSalary)
        {
            var tax = (3572 + (annualSalary - 37000) * 0.325) / 12;
            return Convert.ToInt32(Math.Round(tax, MidpointRounding.AwayFromZero));
        }

        private int Tax4(int annualSalary)
        {
            var tax = (17547 + (annualSalary - 80000) * 0.37) / 12;
            return Convert.ToInt32(Math.Round(tax, MidpointRounding.AwayFromZero));
        }

        private int Tax5(int annualSalary)
        {
            var tax = (54547 + (annualSalary - 180000) * 0.45) / 12;
            return Convert.ToInt32(Math.Round(tax, MidpointRounding.AwayFromZero));
        }
    }
}