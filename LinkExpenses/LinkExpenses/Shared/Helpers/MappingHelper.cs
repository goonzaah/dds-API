using System;
using System.Collections.Generic;

namespace Core.Shared.Helpers
{
    public enum AlgoritmoVinculacion { OrdenValorPrimeroEgreso, OrdenValorPrimeroIngreso, OrdenValorPrimeroEgresoFecha }

    public static class MappingHelper
    {
        private static readonly Dictionary<AlgoritmoVinculacion, bool> _IsEgress = new Dictionary<AlgoritmoVinculacion, bool>()
        {
            { AlgoritmoVinculacion.OrdenValorPrimeroEgreso, false},
            { AlgoritmoVinculacion.OrdenValorPrimeroIngreso, true },
            { AlgoritmoVinculacion.OrdenValorPrimeroEgresoFecha, false }
        };

        public static Dictionary<AlgoritmoVinculacion, bool> IsEgressOrder
        {
            get { return _IsEgress; }
        }
    }
}
