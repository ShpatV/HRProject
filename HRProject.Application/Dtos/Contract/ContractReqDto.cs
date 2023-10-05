using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Application.Dtos.Contract
{
    public class ContractReqDto
    {
        [Required]
        public string Status { get; set; }
        [Required]
        public string PDF { get; set; }
    }
}
