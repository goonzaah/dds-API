﻿using LinkExpenses.Get.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.LinkGenerate
{
    public interface ILinkGenerateStrategy
    {
        LinkedProcessed LinkingTransactions(List<Entry> Ingresos, List<Egress> Egresos);
    }
}
