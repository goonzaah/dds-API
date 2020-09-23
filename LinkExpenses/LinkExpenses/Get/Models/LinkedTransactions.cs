using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.Models
{
    public class LinkedTransactions
    {
        public List<Link> Vinculos { get; set; }
        public string Asociador { get; set; }
    }
}
