﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class APISample
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
    }
}