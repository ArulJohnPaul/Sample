using System;
using System.ComponentModel.DataAnnotations;

namespace PayrollGenerator.Models
{
    public class PayrollModel
    {
        public PayrollModel()
        {

        }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Display(Name = "Pay Month")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy:mm:dd}", ApplyFormatInEditMode = true)]
        public DateTime Month { get; set; }

        [DataType(DataType.Currency)]
        [Range(1, 500000)]
        [Display(Name = "Annual Salary ($)")]
        public int AnnualSalary { get;  set;}

        [Range(1, 50)]
        [Display(Name = "Super Annuation (%)")]
        public int Super { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Pay Period")]
        public string Payperiod { get; set; }

        [Display(Name = "Gross Income ($)")]
        public int GrossIncome { get; set; }

        [Display(Name = "Income tax ($)")]
        public int IncomeTax { get; set; }

        [Display(Name = "Net Income ($)")]
        public int NetIncome { get; set; }

        [Display(Name = "Super Annuation ($)")]
        public int SuperFund { get; set; }
    }
}