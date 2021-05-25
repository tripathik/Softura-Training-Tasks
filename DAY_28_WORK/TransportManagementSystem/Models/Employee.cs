using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }


        [Required]
        public string Loacation { get; set; }


        [Required]
        public int PhoneNumber { get; set; }
    }
}
