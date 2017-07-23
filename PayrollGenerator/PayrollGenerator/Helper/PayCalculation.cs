using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollGenerator.Helper
{
    /// <summary>
    /// This class is written based on the tax slabs are as given for the year 2012 to 2013.
    /// Any changes in the incometax calculation cna be done in the CaclulateIncomeTax() method (ex: adding new tax slab)
    /// Any other changes in the calculated amount can be done the derived class
    /// </summary>
    public abstract class PayCalculation
    {
        protected int AnnualSalary { get; }
       
        public PayCalculation(int AnnualSalary)
        {
            this.AnnualSalary = AnnualSalary;            
        }

        /// <summary>
        /// GrossIncome Calculation
        /// </summary>
        /// <returns></returns>
        public virtual int CalculateGrossIncome()
        {
            if (AnnualSalary == 0)
            {
                throw new InvalidOperationException("Annual Salary Cant be Zero");
            }
            var monthlyIncome = Math.Round(Convert.ToDouble(AnnualSalary) / 12, MidpointRounding.AwayFromZero);
            return Convert.ToInt32(monthlyIncome);
        }

        /// <summary>
        /// NetIncome Calculation
        /// </summary>
        /// <returns></returns>
        public virtual int CalcualteNetIncome()
        {
            return CalculateGrossIncome() - CaclulateIncomeTax();
        }

        /// <summary>
        /// IncomeTax calculation
        /// </summary>
        /// <returns></returns>
        public virtual int CaclulateIncomeTax()
        {
            int incomeTax = 0;
            var taxcases = new Dictionary<Func<int, bool>, Func<int, int>>
            {
                {
                    salary => salary>= 0 && salary<=18200, x=> incomeTax = 0
                },
                {
                    salary => salary>= 18201 && salary<=37000, x => incomeTax = CalculateIncomeTaxFor18201To37000AnnualSalary(AnnualSalary)
                },
                {
                    salary => salary>=37001 && salary<=80000, x => incomeTax = CalculateIncomeTaxfor37001To80000AnnualSalary(AnnualSalary)
                },
                {
                    salary => salary>=80001 && salary<=180000, x=> incomeTax = CalculateIncomeTaxfor80001To180000AnnualSalary(AnnualSalary)
                },
                {
                    salary => salary>180001, x=> incomeTax = CalculateIncomeTaxforAnnualSalary180001AndAbove(x)
                }
            };

            (taxcases.First(x => x.Key(AnnualSalary))).Value.Invoke(AnnualSalary);
            return incomeTax;
        }

        private int CalculateIncomeTaxFor18201To37000AnnualSalary(int annualSalary)
        {
            var tax = ((annualSalary - 18200) * 0.19) / 12;
            return Convert.ToInt32(Math.Round(tax, MidpointRounding.AwayFromZero));
        }

        private int CalculateIncomeTaxfor37001To80000AnnualSalary(int annualSalary)
        {
            var tax = (3572 + (annualSalary - 37000) * 0.325) / 12;
            return Convert.ToInt32(Math.Round(tax, MidpointRounding.AwayFromZero));
        }

        private int CalculateIncomeTaxfor80001To180000AnnualSalary(int annualSalary)
        {
            var tax = (17547 + (annualSalary - 80000) * 0.37) / 12;
            return Convert.ToInt32(Math.Round(tax, MidpointRounding.AwayFromZero));
        }

        private int CalculateIncomeTaxforAnnualSalary180001AndAbove(int annualSalary)
        {
            var tax = (54547 + (annualSalary - 180000) * 0.45) / 12;
            return Convert.ToInt32(Math.Round(tax, MidpointRounding.AwayFromZero));
        }       
    }    
}