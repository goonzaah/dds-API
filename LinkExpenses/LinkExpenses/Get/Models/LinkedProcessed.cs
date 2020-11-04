using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.Models
{
    public class LinkedProcessed
    {
        public List<Link> Links { get; set; }
        public List<Entry> PendingEntries { get; set; }
        public List<Egress> PendingEgresses { get; set; }

    }
}
