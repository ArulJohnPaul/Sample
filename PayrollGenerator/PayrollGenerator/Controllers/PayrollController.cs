using PayrollGenerator.Helper;
using PayrollGenerator.Models;
using System;
using System.Web.Mvc;

namespace PayrollGenerator.Controllers
{
    public class PayrollController : Controller
    {
        private readonly IPayroll payrollHelper;

        public PayrollController()
        {

        }
        public PayrollController(IPayroll payrollHelper)
        {
            this.payrollHelper = payrollHelper;
        }

        // GET: Payroll
        public ActionResult Index()
        {
            var payrollModel = new PayrollModel
            {
                FullName = string.Empty,
                Month = DateTime.Now,
                GrossIncome = 0,                
                IncomeTax = 0,
                NetIncome = 0,
                SuperFund = 0
            };
            return View(payrollModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CalculatePayroll([Bind(Include = "FirstName,LastName, Month, AnnualSalary, Super")] PayrollModel payroll)
        {
            if(ModelState.IsValid)
            {
                IPayroll payrollHelper = new Payroll(payroll.AnnualSalary);
                ISuperAnnuation superAnnuation = new SuperAnnuation(payroll.AnnualSalary, payroll.Super);

                var payrollModel = new PayrollModel
                {
                    FullName = payroll.FirstName + ' ' + payroll.LastName,
                    Month = payroll.Month,
                    Payperiod = payrollHelper.GetPayPeriod(payroll.Month),
                    GrossIncome = payrollHelper.CalculateGrossIncome(),
                    NetIncome = payrollHelper.CalcualteNetIncome(),
                    IncomeTax = payrollHelper.CaclulateIncomeTax(),
                    SuperFund = superAnnuation.CalculateSuperAnnuation()
                };

                return View("Index", payrollModel);
            }
            return View("Index");
        }

        public ActionResult Instructions()
        {
            return View();
        }

        public ActionResult Assumptions()
        {
            return View();
        }        
    }
}