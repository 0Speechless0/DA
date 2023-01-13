using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DA.Services
{
    public static class BigCategoriesService
    {

        public static List<string> getGoodCourseBigCategories()
        {
            using (ttqs_newEntities context = new ttqs_newEntities())
            {
                return context.recommend_class.GroupBy(row => row.CourseCategory)
                    .Select(row => row.Key).ToList();
            }
        }
    }
}