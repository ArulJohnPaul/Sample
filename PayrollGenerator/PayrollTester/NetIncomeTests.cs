using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollGenerator.Helper;

namespace PayrollTester
{
    [TestClass]
    public class NetIncomeTests
    {
        [TestMethod]
        public void TestNetIncomeWithDollar50000AnnualSalary()
        {
            int AnnualSalry = 50000;
            var PayrollHelper = new Payroll(AnnualSalry);
            var netIncome = PayrollHelper.CalcualteNetIncome();
            Assert.AreEqual(3517, netIncome);
        }

        [TestMethod]
        public void TestNetIncomeWithDollar60050AnnualSalary()
        {
            int AnnualSalry = 60050;
            var PayrollHelper = new Payroll(AnnualSalry);
            var netIncome = PayrollHelper.CalcualteNetIncome();
            Assert.AreEqual(4082, netIncome);
        }

        [TestMethod]
        public void TestNetIncomeWithDollar120000AnnualSalary()
        {
            int AnnualSalry = 120000;
            var PayrollHelper = new Payroll(AnnualSalry);
            var netIncome = PayrollHelper.CalcualteNetIncome();
            Assert.AreEqual(7304, netIncome);
        }
    }
}
