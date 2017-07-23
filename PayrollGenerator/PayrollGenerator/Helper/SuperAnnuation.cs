using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollGenerator.Helper
{
    public class SuperAnnuation : PayCalculation, ISuperAnnuation
    {
        protected int SuperPercentage { get; }

        public SuperAnnuation(int AnnualSalary, int superPercentage) : base(AnnualSalary)
        {
            this.SuperPercentage = superPercentage;
        }

        public int CalculateSuperAnnuation()
        {
            var res = base.CalculateGrossIncome() * Math.Round(Convert.ToDouble(SuperPercentage) / 100, 3);
            return Convert.ToInt32(res);
        }
    }
}