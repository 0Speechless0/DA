using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DA.Services
{
    public class DiagramBaseService<T> where T : class
    {
        public List<T> dataSource { get; set; }
        public void loadDataSource(DbSet<T> data, Func<T, bool> simplification = null)
        {

            using (ttqs_newEntities context = new ttqs_newEntities())
            {

                dataSource = data
                .Where((simplification) ?? (row => true))
                .ToList();

            }

        }
    }
}