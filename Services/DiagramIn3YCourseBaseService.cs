using DA.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DA.Common;

namespace DA.Services
{
    public class DiagramIn3YCourseBaseService<T> : DiagramBaseService<T>, IDiagramBaseService<T> where T : class
    {
        private static Dictionary<string, Dictionary<string, Dictionary<string, List<T>>>> DataBuilded { get; set; }


        /// <param name="categorySelector">關鍵字搜尋欄位</param>
        /// <param name="searchWrod">關鍵字</param>
        /// <returns>使用者名稱</returns>


        public void buildDataSource(Func<T, decimal> dataSelector, params Func<T, object>[] keySelector)
        {

            DataBuilded = dataSource
                .GroupBy(keySelector[0])
                .OrderByDescending(row => row.Sum(dataSelector))
               .ToDictionary(
                    row => row.Key.ToString(),
                    row => row.GroupBy(keySelector[1])
                        .ToDictionary(
                        row2 => row2.Key.ToString(),
                        row2 => row2
                            .GroupBy(keySelector[2])
                            .OrderByDescending(row3 => row3.Sum(dataSelector))
                            .ToDictionary(
                                row3 => row3.Key.ToString(),
                                row3 => row3.ToList()
                            )
                        )

                );
        }

        public List<TResult> getCategoriesMost<TResult>(Func<T, TResult> selector)
        {
            return DataBuilded
                    .Keys.Take(10)
                    .Cast<TResult>()
                    .ToList();
        }

        public List<decimal> getCategriesDataInYear(int year, Func<T, decimal> keySelector)
        {
            return DataBuilded
                .Take(10)
                .Select(row =>
                    row.Value
                        .Where(row2 => row2.Key == year.ToString())
                        .Sum(
                            row2 =>
                            row2.Value.Sum(
                                row3 => row3.Value.Sum(keySelector)
                                )
                            )
                )
                .Select(row => decimal.Round(row, 1))
                .ToList();


        }

        public List<decimal> getCategoryYearData(int year, string category, Func<T, decimal> keySelector, Func<T, DateTime?> predicate = null)
        {
            if (!DataBuilded[category].ContainsKey(year.ToString())) return new List<decimal>();
            return DataBuilded[category][year.ToString()]
                .Take(10)
                .Select(row =>
                    row.Value.Sum(
                            keySelector
                        )
                )
                .Select(row => decimal.Round(row, 1))
                .ToList();
        }
        public List<CloudWord> getCloudWordsV2(Func<T, int> dataSelector)
        {
            return DataBuilded.Select(row =>
                   new CloudWord
                   {
                       name = row.Key,
                       weight =decimal.Round(row.Value.Sum(row2 =>
                           row2.Value.Sum(
                                row3 => row3.Value.Sum(dataSelector)
                            )
                        ), 1)

                   }
                ).Where(row => row.weight > 0 ).ToList();
        }



        public List<CloudWord> getCloudWords(Func<T, object> categorySelector, Func<T, decimal> dataSelector)
        {
            throw new NotImplementedException();
        }
        
        public List<string> getSubCategories(int year, string category)
        {
            if (!DataBuilded[category].ContainsKey(year.ToString())) return new List<string>();
            return DataBuilded[category][year.ToString()].Keys.Take(10).ToList();
        }


    }
}