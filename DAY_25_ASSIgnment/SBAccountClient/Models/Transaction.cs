using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBAccountClient.Models
{
    public partial class Transaction
    {
       
        public int TransactionId { get; set; }
        public DateTime Transactiondate { get; set; }
        public int AccountNumber { get; set; }
        public float Ammount { get; set; }
        public String Transactiontype { get; set; }
    }
}
