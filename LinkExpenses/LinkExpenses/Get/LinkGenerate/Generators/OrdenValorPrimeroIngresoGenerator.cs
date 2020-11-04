using LinkExpenses.Get.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.LinkGenerate.Generators
{
    public class OrdenValorPrimeroIngresoGenerator : ILinkGenerateStrategy
    {
        public LinkedProcessed LinkingTransactions(List<Entry> Ingresos, List<Egress> Egresos)
        {
            var linked = Algorithms.PrimeroIngreso(Ingresos.OrderBy(x => x.Monto).ToList(), Egresos.OrderBy(x => x.Monto).ToList());
            return linked;
        }
    }
}
