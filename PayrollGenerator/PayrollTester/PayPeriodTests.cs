using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollGenerator.Helper;

namespace PayrollTester
{
    [TestClass]
    public class PayPeriodTests
    {
        [TestMethod]
        public void TestPayPeriodForJuly2017()
        {
            int AnnualSalry = 50000;
            var month = new DateTime(2017, 7, 10);
            var PayrollHelper = new Payroll(AnnualSalry);
            var payPeriod = PayrollHelper.GetPayPeriod(month);
            Assert.AreEqual("01 July - 31 July", payPeriod);
        }

        [TestMethod]
        public void TestPayPeriodForApril2017()
        {
            int AnnualSalry = 50000;
            var month = new DateTime(2017, 4, 10);
            var PayrollHelper = new Payroll(AnnualSalry);
            var payPeriod = PayrollHelper.GetPayPeriod(month);
            Assert.AreEqual("01 April - 30 April", payPeriod);
        }

        [TestMethod]
        public void TestPayPeriodForFebruary2017()
        {
            int AnnualSalry = 50000;
            var month = new DateTime(2017, 2, 10);
            var PayrollHelper = new Payroll(AnnualSalry);
            var payPeriod = PayrollHelper.GetPayPeriod(month);
            Assert.AreEqual("01 February - 28 February", payPeriod);
        }

        [TestMethod]
        public void TestPayPeriodForFebruary2016()
        {
            int AnnualSalry = 50000;
            var month = new DateTime(2016, 2, 10);
            var PayrollHelper = new Payroll(AnnualSalry);
            var payPeriod = PayrollHelper.GetPayPeriod(month);
            //Leap year
            Assert.AreEqual("01 February - 29 February", payPeriod);
        }
    }
}
