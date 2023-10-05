using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Application.Dtos.Contract
{
    public class ContractResDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
