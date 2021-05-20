using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBAccountClient.Models
{
    public partial class SBAccount
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public float CurrentBalance { get; set; }
    }
}
