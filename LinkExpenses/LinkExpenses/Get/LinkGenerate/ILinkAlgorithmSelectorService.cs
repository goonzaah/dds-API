using LinkExpenses.Get.LinkGenerate;
using LinkExpenses.Get.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkExpenses.Get.LinkGenerate
{
    interface ILinkAlgorithmSelectorService
    {
        ILinkGenerateStrategy GetLinkingGenerator(AlgoritmoVinculacion? algoritmo);
    }
}
