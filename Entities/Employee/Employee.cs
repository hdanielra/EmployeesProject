using System.ComponentModel.DataAnnotations;

namespace Employees.Entities.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string EmployeeName { get; set; }
        public decimal EmployeeSalary { get; set; }
        public int EmployeeAge { get; set; }
        public string ProfileImage { get; set; }

    }
}
