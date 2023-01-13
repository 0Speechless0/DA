using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA.VModels
{
    public class YearGroupVM<T>
    {
        public int Year { get; set; }

        public Dictionary< string, List<T> > categoryGroup {get; set ;}
    }
}