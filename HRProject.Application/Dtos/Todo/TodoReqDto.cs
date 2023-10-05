using System.ComponentModel.DataAnnotations;

namespace HRProject.Application.Dtos.Todo
{
    public class TodoReqDto
    {
        [Required]
        public string Name { get; set; }
    }
}
