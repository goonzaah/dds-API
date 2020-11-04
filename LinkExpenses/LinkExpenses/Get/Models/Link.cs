using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkExpenses.Get.Models
{
    public class Link
    {
        public int IdAsociador { get; set; }
        public int[] IdAsociados { get; set; }
    }
}
