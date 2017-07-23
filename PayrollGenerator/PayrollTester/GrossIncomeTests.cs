using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollGenerator.Helper;

namespace PayrollTester
{
    [TestClass]
    public class GrossIncomeTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestGrossIncomeWithZeroAnnualSalary()
        {
            int AnnualSalry = 0;            
            var PayrollHelper = new Payroll(AnnualSalry);
            var monthlyIncome = PayrollHelper.CalculateGrossIncome();            
        }

        [TestMethod]
        public void TestGrossIncomeWithDollar47000AnnualSalary()
        {
            int AnnualSalry = 47000;            
            var PayrollHelper = new Payroll(AnnualSalry);
            var monthlyIncome = PayrollHelper.CalculateGrossIncome();
            // monthly income $3916.66 is converted to $3917
            Assert.AreEqual(monthlyIncome, 3917);
        }

        [TestMethod]
        public void TestGrossIncomeWithDollar46998AnnualSalary()
        {
            int AnnualSalry = 46998;
            var PayrollHelper = new Payroll(AnnualSalry);
            var monthlyIncome = PayrollHelper.CalculateGrossIncome();
            // montly income $3916.50 is converted to $3917
            Assert.AreEqual(monthlyIncome, 3917);
        }

        [TestMethod]
        public void TestGrossIncomeWithDollar46996AnnualSalary()
        {
            int AnnualSalry = 46996;
            var PayrollHelper = new Payroll(AnnualSalry);
            var monthlyIncome = PayrollHelper.CalculateGrossIncome();
            // montly income $3916.33 is converted to $3916
            Assert.AreEqual(monthlyIncome, 3916);
        }      
    }
}
