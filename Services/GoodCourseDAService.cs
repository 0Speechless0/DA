using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA.Interface;
namespace DA.Services
{
    public class GoodCourseDAService : DiagramIn3YCourseBaseService<recommend_class>, IDiagramService
    {

        private Func<string, int> minStringConvert = (str) => Int32.Parse(str.Replace("分鐘", String.Empty));
        private Func<decimal, decimal> toHour = (min) => decimal.Round(min/60, 2);
        public GoodCourseDAService(string BigCategory, string SubCategiry)
            : base(dbset => dbset.recommend_class, 
                  row => 
                        row.CourseCategory == BigCategory &&
                        row.CourseSubcategory.Contains(SubCategiry ?? String.Empty))
        {

            buildDataSource(
                row => minStringConvert.Invoke(row.CourseTime) ,
                row => row.CourseSubcategory,
                row => row.CreatDate?.Year,
                row => row.CourseTitle
            );
        } 
        public List<string> getCategories(string word = "")
        {
            return getCategoriesMost(row => row.CourseSubcategory);
        }

        public List<decimal> getCategriesDataInYear(int year, string word = "")
        {
            return base.getCategriesDataInYear(year, row => minStringConvert.Invoke(row.CourseTime))
                .Select( row => toHour.Invoke(row) ).ToList();
        }

        public List<decimal> getCategoryYearData(int year, string category)
        {
            return base.getCategoryYearData(year, category, row => minStringConvert.Invoke(row.CourseTime))
                .Select(row => toHour.Invoke(row)).ToList();
        }

        public List<CloudWord> getCloudWords()
        {
            return base.getCloudWords(row => minStringConvert.Invoke(row.CourseTime))
                .Select(row => new CloudWord{ 
                    name = row.name,
                    weight = toHour.Invoke(row.weight)

                }).ToList();
        }


        public List<string> getBigCategories()
        {
            using (ttqs_newEntities context = new ttqs_newEntities())
            {
                return context.recommend_class.GroupBy(row => row.CourseCategory)
                    .Select(row => row.Key).ToList();
            }
        }
        public List<string> getSubCategories(int year, string category)
        {
            return base.getSubCategories(year, category);
        }
    }


}