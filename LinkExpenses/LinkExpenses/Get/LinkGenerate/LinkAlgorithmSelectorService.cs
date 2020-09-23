using LinkExpenses.Get.LinkGenerate.Generators;
using LinkExpenses.Get.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkExpenses.Get.LinkGenerate
{

    public static class LinkAlgorithmSelectorService
    {
        public static ILinkGenerateStrategy GetLinkingGenerator(AlgoritmoVinculacion? algoritmo)
        {
            switch (algoritmo)
            {
                case AlgoritmoVinculacion.OrdenValorPrimeroEgreso:
                    return new OrdenValorPrimeroEgresoGenerator();

                case AlgoritmoVinculacion.OrdenValorPrimeroIngreso:
                    return new OrdenValorPrimeroIngresoGenerator();

                case AlgoritmoVinculacion.OrdenValorPrimeroEgresoFecha:
                    return new OrdenValorPrimeroEgresoFechaGenerator();

                default:
                    return null;

            }
        }
    }
}
