using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Application.Dtos.Country
{
    public class CountryReqDto
    {
        [Required]
        public string StateName { get; set; }
    }
}
