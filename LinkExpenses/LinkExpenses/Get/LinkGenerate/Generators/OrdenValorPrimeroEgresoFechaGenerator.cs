﻿using LinkExpenses.Get.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.LinkGenerate.Generators
{
    public class OrdenValorPrimeroEgresoFechaGenerator : ILinkGenerateStrategy
    {
        public LinkedProcessed LinkingTransactions(List<Entry> Ingresos, List<Egress> Egresos)
        {
            var linked = Algorithms.PrimeroEgreso(Ingresos.OrderBy(x => x.Monto).ToList(), Egresos.OrderBy(x => x.Monto).ToList());
            return linked;
        }
    }
}
