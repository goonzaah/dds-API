using LinkExpenses.Get.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.LinkGenerate
{
    public static class Algorithms
    {
        public static List<Link> PrimeroEgreso(List<Entry> Ingresos, List<Egress> Egresos) {

            var links = new List<Link>();

            var pendingEntries = Ingresos;

            foreach (var egress in Egresos)
            {
                List<Entry> entriesLinked = new List<Entry>();

                decimal summary = 0;

                var entries = pendingEntries;

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
                    links.Add(new Link() { IdAsociador = egress.Id, IdAsociados = entriesLinked.Select(x => x.Id).ToList() });
                if (pendingEntries.Count == 0)
                    break;
            }

            return links;
        }

        public static List<Link> PrimeroIngreso(List<Entry> Ingresos, List<Egress> Egresos)
        {

            var links = new List<Link>();

            var pendingEntries = Ingresos;

            foreach (var egress in Egresos)
            {
                List<int> entriesLinkedIds = new List<int>();

                decimal summary = 0;

                var entries = pendingEntries;

                foreach (Entry entry in entries)
                {
                    if (entry.Monto < egress.Monto && RangeAccepted(egress.FechaOperacion, entry.RangoAceptabilidad))
                    {
                        summary += entry.Monto;
                        pendingEntries.Remove(entry);
                        entriesLinkedIds.Add(entry.Id);
                    }

                    else if (entry.Monto == egress.Monto && RangeAccepted(egress.FechaOperacion, entry.RangoAceptabilidad))
                    {
                        pendingEntries.Remove(entry);
                        entriesLinkedIds.Add(entry.Id);
                        break;
                    }
                }

                if (entriesLinkedIds.Count > 0)
                    links.Add(new Link() { IdAsociador = egress.Id, IdAsociados = entriesLinkedIds });
                if (pendingEntries.Count == 0)
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
