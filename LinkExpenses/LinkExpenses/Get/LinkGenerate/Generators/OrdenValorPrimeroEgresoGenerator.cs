using LinkExpenses.Get.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.LinkGenerate.Generators
{
    public class OrdenValorPrimeroEgresoGenerator : ILinkGenerateStrategy
    {
        public List<Link> LinkingTransactions(TransactionsModel request)
        {
            // Faltan las validaciones
            return Algorithms.PrimeroEgreso(request.Ingresos.OrderBy(x => x.Monto).ToList(), request.Egresos.OrderBy(x => x.Monto).ToList());
        }
    }
}
