using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class Route
    {
        [Key]
        public int RouteNumber { get; set; }
        public string Stops { get; set; }
        public int VehicleNumber { get; set; }
    }
}
