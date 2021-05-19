﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBAccountWebApi.Models
{
    public class SBAccount
    {
        [Key]
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public float CurrentBalance { get; set; }
    }
}
