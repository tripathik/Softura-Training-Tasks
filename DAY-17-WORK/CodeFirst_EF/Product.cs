using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstEg
{
    class Product
    {
        [Key]
        public int Pid { get; set; }
        public string Pname { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }

        public override string ToString()
        {
            return ("Pid "+Pid+ " Pname : "+Pname+" Price: "+Price+ " Quantity: " +Qty);
        }
    }
}
