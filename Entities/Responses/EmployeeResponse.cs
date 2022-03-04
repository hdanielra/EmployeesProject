using System.ComponentModel.DataAnnotations;

namespace Employees.Entities.Responses
{
    public class EmployeeResponse
    {
        public int Id { get; set; }

        public string Employee_Name { get; set; }
        public decimal Employee_Salary { get; set; }
        public int Employee_Age { get; set; }
        public string Profile_Image { get; set; }

    }
}
