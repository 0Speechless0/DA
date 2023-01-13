using DA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA.Common;

namespace DA.Services
{
    public class CourseDAService : DiagramIn3YBaseService<course>, IDiagramService
    {

        public static Dictionary<int, string> functionCategoryMap = new Dictionary<int, string>();
        public CourseDAService(string searchWord) : base( dbset => dbset.course )
        {
            functionCategoryMap[0] = null;

            using (ttqs_newEntities context = new ttqs_newEntities())
            {
                functionCategoryMap = (
                    from row in context.function_category
                select row).ToDictionary(row => row.Seq, row =>row.Name);
            }
            dataSource = dataSource.Where(row => functionCategoryMap[row.FunctionCategory?? 0].Contains(searchWord ?? String.Empty)).ToList();

            buildDataSource(
                row => 1,
                row => row.CreatDate.Year, 
                row => functionCategoryMap[row.FunctionCategory ?? 0] );
        }

        public List<string> getCategories(string word = "")
        {
            if(word != "")
            {
                _lastCategoriesByWord = getCategoriesByWord(word, row => functionCategoryMap[row.FunctionCategory ?? 0]);
                return _lastCategoriesByWord;
            }
            return getCategoriesMost(row => functionCategoryMap[row.FunctionCategory ?? 0])
                .ToList();
        }

        private List<string> _lastCategoriesByWord;

        public List<decimal> getCategriesDataInYear(int year, string word ="")
        {
            if(word != "" )
            {
                return getCategoryDataByWordInYear(year, _lastCategoriesByWord, row => 1);
            }
            return getCategriesDataInYear(year, row => 1);
        }

        public List<decimal> getCategoryYearData(int year, string category)
        {
            return getCategoryYearData(year, category, row => 1, row => row.CreatDate);
        }

        public List<CloudWord> getCloudWords()
        {
            return getCloudWords(row => functionCategoryMap[row.FunctionCategory ?? 0], row => 1 );
        }

        public List<decimal> getCategriesDataInYearV2(int year, string word = "")
        {
            return getCategriesDataInYear(year, word).Cast<decimal>().ToList();
        }

        public List<decimal> getCategoryYearDataV2(int year, string category)
        {
            return getCategoryYearData(year, category).Cast<decimal>().ToList();
        }

        public List<object> getCloudWordsV2()
        {
            return getCloudWords().Cast<object>().ToList();
        }

        public List<string> getBigCategories()
        {
            throw new NotImplementedException();
        }


    }
}