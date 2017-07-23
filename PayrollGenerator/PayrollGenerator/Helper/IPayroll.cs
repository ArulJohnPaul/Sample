using System;

namespace PayrollGenerator.Helper
{
    public interface IPayroll
    {
        int CaclulateIncomeTax();

        int CalcualteNetIncome();

        int CalculateGrossIncome();

        string GetPayPeriod(DateTime paymonth);
    }
}
