using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA.Interface;
namespace DA.Models
{
    public class ServiceSwitchModel
    {
        public IDiagramService Service { get; set; }
        public IDiagramService SearchService { get; set; } 
        public Func<List<string>> getBigCategoriesService{ get; set; } 
        public string ViewTitle { get; set; }
    }
}