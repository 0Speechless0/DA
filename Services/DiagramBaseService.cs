using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DA.Services
{
    public class DiagramBaseService<T> where T : class
    {
        public Func<T, bool> _simplification { get; set; }
        public List<T> dataSource { get; set; }
        public void loadDataSource(DbSet<T> data)
        {
            dataSource = data
            .Where((_simplification) ?? (row => true))
            .ToList();
        }
    }
}