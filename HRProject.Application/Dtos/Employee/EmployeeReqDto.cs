using System.ComponentModel.DataAnnotations;

namespace HRProject.Application.Dtos.Employee
{
    public class EmployeeReqDto
    {

        [Required]
        public string Name { get; set; }


    }
}
