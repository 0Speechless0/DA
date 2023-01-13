using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA.VModels
{
    public class GroupFusionVM<T>
    {
        public T groupKey {get;set;}
        public int Fusion { get; set; }
    }
}