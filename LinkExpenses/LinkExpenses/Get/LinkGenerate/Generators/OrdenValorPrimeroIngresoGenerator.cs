using LinkExpenses.Get.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.LinkGenerate.Generators
{
    public class OrdenValorPrimeroIngresoGenerator : ILinkGenerateStrategy
    {
        public List<Link> LinkingTransactions(TransactionsModel request)
        {
            return Algorithms.PrimeroIngreso(request.Ingresos.OrderBy(x => x.Monto).ToList(), request.Egresos.OrderBy(x => x.Monto).ToList());
        }
    }
}
