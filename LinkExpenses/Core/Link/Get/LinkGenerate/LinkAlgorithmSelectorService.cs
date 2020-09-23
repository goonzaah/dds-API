using Core.Link.Get.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Link.Get.LinkGenerate
{
    class LinkAlgorithmSelectorService
    {

        public IExecuteNoveltyStrategy GetNoveltyExecutor(AlgoritmoVinculacion? algoritmo)
        {
            switch (algoritmo)
            {
                case AlgoritmoVinculacion.OrdenValorPrimeroEgreso:
                    return new LogicRecievedExecutor();

                case AlgoritmoVinculacion.OrdenValorPrimeroIngreso:
                    return new ImpositionExecutor();

                case AlgoritmoVinculacion.Dispatch:
                    return new DispatchExecutor();

                case AlgoritmoVinculacion.RoadMap:
                    return new RoadMapExecutor();

                default:
                    return null;

            }
        }
    }
}
