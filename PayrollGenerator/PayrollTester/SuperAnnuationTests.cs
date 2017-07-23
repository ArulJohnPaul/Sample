using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollGenerator.Helper;

namespace PayrollTester
{
    [TestClass]
    public class SuperAnnuationTests
    {
        [TestMethod]
        public void TestSuperAnnuationWithDollar50000AnnualSalaryAnd2Super()
        {
            int AnnualSalry = 50000;
            int Super = 2;
            var PayrollHelper = new SuperAnnuation(AnnualSalry, Super);
            var super = PayrollHelper.CalculateSuperAnnuation();
            Assert.AreEqual(83, super);
        }

        [TestMethod]
        public void TestSuperAnnuationWithDollar60050AnnualSalaryAnd9Super()
        {
            int AnnualSalry = 60050;
            int Super = 9;
            var PayrollHelper = new SuperAnnuation(AnnualSalry, Super);
            var super = PayrollHelper.CalculateSuperAnnuation();
            Assert.AreEqual(450, super);
        }

        [TestMethod]
        public void TestSuperAnnuationWithDollar120000AnnualSalaryAnd10Super()
        {
            int AnnualSalry = 120000;
            int Super = 10;
            var PayrollHelper = new SuperAnnuation(AnnualSalry, Super);
            var super = PayrollHelper.CalculateSuperAnnuation();
            Assert.AreEqual(1000, super);
        }
    }
}
