using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.Models
{
    public class LinkedTransactions
    {
        public List<Link> VinculosEgreso { get; set; }

        public List<Link> VinculosIngreso { get; set; }
        
    }
}
