﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Application.Dtos.Position
{
    public class PositionReqDto
    {
        [Required]
        public string Name { get; set; }
    }
}
