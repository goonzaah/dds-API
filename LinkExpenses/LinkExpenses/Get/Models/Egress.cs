using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.Models
{
    
    public class Egress
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaOperacion { get; set; }
    }
}
