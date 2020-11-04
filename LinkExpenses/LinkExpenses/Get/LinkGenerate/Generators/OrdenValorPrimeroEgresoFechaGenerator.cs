using LinkExpenses.Get.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.LinkGenerate.Generators
{
    public class OrdenValorPrimeroEgresoFechaGenerator : ILinkGenerateStrategy
    {
        public List<Link> LinkingTransactions(TransactionsModel request)
        {
            var linked = Algorithms.PrimeroEgreso(request.Ingresos.OrderBy(x => x.Monto).ToList(), request.Egresos.OrderBy(x => x.Monto).ToList());
            return linked;
        }
    }
}
