using System;
using System.Collections.Generic;
using System.Text;

namespace LinkExpenses.Get.Models
{
    public enum AlgoritmoVinculacion { OrdenValorPrimeroEgreso, OrdenValorPrimeroIngreso, OrdenValorPrimeroEgresoFecha, Mix }
    public class TransactionsModel
    {
        public List<Entry> Ingresos { get; set; }
        public List<Egress> Egresos { get; set; }
        public AlgoritmoVinculacion Criterio { get; set; }
    }
}
