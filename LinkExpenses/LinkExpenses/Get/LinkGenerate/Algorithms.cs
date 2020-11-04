using LinkExpenses.Get.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.LinkGenerate
{
    public static class Algorithms
    {
        //agrupa por egreso
        public static List<Link> PrimeroIngreso(List<Entry> Ingresos, List<Egress> Egresos) {

            var links = new List<Link>();

            var pendingEntries = Ingresos;

            foreach (var egress in Egresos)
            {
                List<Entry> entriesLinked = new List<Entry>();

                decimal summary = 0;

                var entries = pendingEntries.ToList();

                foreach (Entry entry in entries)
                {
                    if (entry.Monto < egress.Monto && RangeAccepted(egress.FechaOperacion, entry.RangoAceptabilidad))
                    {
                        summary += entry.Monto;
                        pendingEntries.Remove(entry);
                        entriesLinked.Add(entry);
                    }
                    else if (entry.Monto == egress.Monto && RangeAccepted(egress.FechaOperacion, entry.RangoAceptabilidad))
                    {
                        pendingEntries.Remove(entry);
                        entriesLinked.Add(entry);
                        break;
                    }
                }
                if (entriesLinked.Count > 0)
                    links.Add(new Link() { IdAsociador = egress.Id, IdAsociados = entriesLinked.Select(x => x.Id).ToArray() });
                if (pendingEntries.Count == 0)
                    break;
            }

            return links;
        }
        //agrupa por ingreso
        public static List<Link> PrimeroEgreso(List<Entry> Ingresos, List<Egress> Egresos)
        {

            var links = new List<Link>();

            var pendingEgresses = Egresos;

            foreach (var entry in Ingresos)
            {
                List<int> egressesLinkedIds = new List<int>();

                decimal summary = 0;

                foreach (Egress egress in pendingEgresses.ToList())
                {
                    if (entry.Monto > egress.Monto && RangeAccepted(egress.FechaOperacion, entry.RangoAceptabilidad))
                    {
                        summary += egress.Monto;
                        pendingEgresses.Remove(egress);
                        egressesLinkedIds.Add(egress.Id);
                    }

                    else if (entry.Monto == egress.Monto && RangeAccepted(egress.FechaOperacion, entry.RangoAceptabilidad))
                    {
                        pendingEgresses.Remove(egress);
                        egressesLinkedIds.Add(egress.Id);
                        break;
                    }
                }

                if (egressesLinkedIds.Count > 0)
                    links.Add(new Link() { IdAsociador = entry.Id, IdAsociados = egressesLinkedIds.ToArray() });
                if (pendingEgresses.Count == 0)
                    break;
            }

            return links;
        }


        private static bool RangeAccepted(DateTime date, AceptabilityRange aceptabilityRange)
        {
            return (date >= aceptabilityRange.FechaInicio && date <= aceptabilityRange.FechaFin);
        }
    }
}
