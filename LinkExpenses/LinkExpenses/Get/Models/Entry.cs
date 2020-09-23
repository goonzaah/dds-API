using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.Models
{
    public class AceptabilityRange
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
    public class Entry
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaOperacion { get; set; }
        public AceptabilityRange RangoAceptabilidad { get; set; }
    }
}
