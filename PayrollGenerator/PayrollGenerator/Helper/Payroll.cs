using System;

namespace PayrollGenerator.Helper
{
    /// <summary>
    /// This class is written to override any calculated values as per the need
    /// </summary>
    public class Payroll: PayCalculation, IPayroll
    {
        public Payroll(int AnnualSalary) : base(AnnualSalary)
        {
           
        }

        public override int CaclulateIncomeTax()
        {
            return base.CaclulateIncomeTax();
        }

        public override int CalcualteNetIncome()
        {
            return base.CalcualteNetIncome();
        }

        public override int CalculateGrossIncome()
        {
            return base.CalculateGrossIncome();
        }

        /// <summary>
        /// Method to format the pay period
        /// </summary>
        /// <param name="paymonth"></param>
        /// <returns></returns>
        public string GetPayPeriod(DateTime paymonth)
        {
            var payPeriod = String.Format("01 {0} - {1} {2}",
                paymonth.ToString("MMMMM"), DateTime.DaysInMonth(paymonth.Year, paymonth.Month), paymonth.ToString("MMMMM"));
            return payPeriod;
        }
    }
}