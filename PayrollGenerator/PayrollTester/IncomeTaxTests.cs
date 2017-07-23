using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollGenerator.Helper;

namespace PayrollTester
{
    [TestClass]
    public class IncomeTaxTests
    {
        [TestMethod]
        public void TestIncomeTaxforZeroAnnualSalary()
        {
            int AnnualSalry = 0;
            var PayrollHelper = new Payroll(AnnualSalry);
            var incomeTax = PayrollHelper.CaclulateIncomeTax();
            Assert.AreEqual(0, incomeTax);
        }

        [TestMethod]
        public void TestIncomeTaxfor18000AnnualSalary()
        {
            int AnnualSalry = 18000;
            var PayrollHelper = new Payroll(AnnualSalry);
            var incomeTax = PayrollHelper.CaclulateIncomeTax();
            Assert.AreEqual(0, incomeTax);
        }

        [TestMethod]
        public void TestIncomeTaxfor35000AnnualSalary()
        {
            int AnnualSalry = 35000;
            var PayrollHelper = new Payroll(AnnualSalry);
            var incomeTax = PayrollHelper.CaclulateIncomeTax();
            Assert.AreEqual(266, incomeTax);
        }

        [TestMethod]
        public void TestIncomeTaxfor60050AnnualSalary()
        {
            int AnnualSalry = 60050;
            var PayrollHelper = new Payroll(AnnualSalry);
            var incomeTax = PayrollHelper.CaclulateIncomeTax();
            Assert.AreEqual(922, incomeTax);
        }

        [TestMethod]
        public void TestIncomeTaxfor100000AnnualSalary()
        {
            int AnnualSalry = 100000;
            var PayrollHelper = new Payroll(AnnualSalry);
            var incomeTax = PayrollHelper.CaclulateIncomeTax();
            Assert.AreEqual(2079, incomeTax);
        }

        [TestMethod]
        public void TestIncomeTaxfor190000AnnualSalary()
        {
            int AnnualSalry = 190000;
            var PayrollHelper = new Payroll(AnnualSalry);
            var incomeTax = PayrollHelper.CaclulateIncomeTax();
            Assert.AreEqual(4921, incomeTax);
        }
    }
}
