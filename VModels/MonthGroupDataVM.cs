using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA.VModels
{
    public class MonthGroupDataVM
    {
        public DateTime? groupKey { get; set; }
        public decimal groupSum { get; set; }
    }
}