using DA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA.Common;

namespace DA.Services
{
    public class CourseDAService :  IDiagramService
    {

        public static Dictionary<int, string> functionCategoryMap = new Dictionary<int, string>();

        private IDiagramBaseService<course> _service;

        public CourseDAService()
        {
            _service = new DiagramIn3YBaseService<course>();
        }
        public void dataBuild(string[] searchWord)
        {

            using (ttqs_newEntities context = new ttqs_newEntities())
            {
                functionCategoryMap = (
                    from row in context.function_category
                    select row).ToDictionary(row => row.Seq, row => row.Name);

                _service.loadDataSource(context.course, row => functionCategoryMap[row.FunctionCategory ?? 0].Contains(searchWord[0] ?? String.Empty));
            }

            _service.buildDataSource(
                row => 1,
                row => row.CreatDate.Year, 
                row => functionCategoryMap[row.FunctionCategory ?? 0] );


        }

        public List<string> getCategories()
        {

            return _service.getCategoriesMost(row => functionCategoryMap[row.FunctionCategory ?? 0])
                .ToList();
        }


        public List<decimal> getCategriesDataInYear(int year)
        {

            return _service.getCategriesDataInYear(year, row => 1);
        }

        public List<decimal> getCategoryYearData(int year, string category)
        {
            return _service.getCategoryYearData(year, category, row => 1, row => row.CreatDate);
        }

        public List<CloudWord> getCloudWords()
        {
            return _service.getCloudWords(row => functionCategoryMap[row.FunctionCategory ?? 0], row => 1 );
        }


        public List<string> getBigCategories()
        {
            throw new NotImplementedException();
        }

        public List<string> getSubCategories(int year, string category)
        {
            return _service.getSubCategories(year, category);
        }


    }
}