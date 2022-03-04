using System.ComponentModel.DataAnnotations;

namespace Employees.Entities.ViewModels
{
    public class EmployeeDisplayViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Name")]
        public string EmployeeName { get; set; }


        [Display(Name = "Salary")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal EmployeeSalary { get; set; }


        [Display(Name = "Age")]
        public int EmployeeAge { get; set; }


        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }


        [Display(Name = "Anual Salary")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal EmployeeAnualSalary { get { return EmployeeSalary * 12; } }

    }
}
