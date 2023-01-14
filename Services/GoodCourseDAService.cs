using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA.Interface;
namespace DA.Services
{
    public class GoodCourseDAService : IDiagramService
    {

        private Func<string, int> minStringConvert = (str) => Int32.Parse(str.Replace("分鐘", String.Empty));
        private Func<decimal, decimal> toHour = (min) => decimal.Round(min/60, 2);
        IDiagramBaseService<recommend_class> _service;

        public GoodCourseDAService()
        {
            _service =new DiagramIn3YCourseBaseService<recommend_class>();
        }
        public void dataBuild(string[] searchWord)
        {

            using (ttqs_newEntities context = new ttqs_newEntities())
            {

                _service.loadDataSource(context.recommend_class,
                    row =>
                    row.CourseCategory == searchWord[0] &&
                        row.CourseSubcategory.Contains(searchWord[1] ?? String.Empty));
            }

            _service.buildDataSource(
                row => minStringConvert.Invoke(row.CourseTime) ,
                row => row.CourseSubcategory,
                row => row.CreatDate?.Year,
                row => row.CourseTitle
            );


        }

         public List<string> getCategories()
        {
            return _service.getCategoriesMost(row => row.CourseSubcategory);
        }

        public List<decimal> getCategriesDataInYear(int year)
        {
            return _service.getCategriesDataInYear(year, row => minStringConvert.Invoke(row.CourseTime))
                .Select( row => toHour.Invoke(row) ).ToList();
        }

        public List<decimal> getCategoryYearData(int year, string category)
        {
            return _service.getCategoryYearData(year, category, row => minStringConvert.Invoke(row.CourseTime))
                .Select(row => toHour.Invoke(row)).ToList();
        }

        public List<CloudWord> getCloudWords()
        {
            return _service.getCloudWordsV2(row => minStringConvert.Invoke(row.CourseTime))
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
            return _service.getSubCategories(year, category);
        }
    }


}