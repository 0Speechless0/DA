using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DA.Interface;
using DA;
using DA.VModels;
using System.Collections;

namespace DA.Services
{
    public abstract class DiagramIn3YBaseService<T> : DiagramBaseService<T>, IDiagramBaseService<T> where T : class
    {
        public class monthCompare : IEqualityComparer<DateTime?>
        {
            public bool Equals(DateTime? x, DateTime? y)
            {
                return x?.Month == y?.Month;
            }

            public int GetHashCode(DateTime? obj)
            {
                return obj?.Month ?? -1;
            }
        }

        public class CategoryComparer : IComparer<string>
        {
            private Dictionary<string, int> _categoriesOrder;
            public CategoryComparer(Dictionary<string, int> topCategories)
            {
                _categoriesOrder = topCategories;
            }
            public int Compare(string x, string y)
            {

                if (_categoriesOrder[x] > _categoriesOrder[y]) return 1;
                if (_categoriesOrder[x] < _categoriesOrder[y]) return -1;

                return 0;
            }
        }

        public DiagramIn3YBaseService(Func<ttqs_newEntities, DbSet<T> > dbSetSelector, Func<T, bool> simplification =null)
        {
            _simplification = simplification;

            using (ttqs_newEntities context = new ttqs_newEntities ())
            {

                loadDataSource(dbSetSelector.Invoke(context));
                
            }

        
        }
        public Dictionary<string, Dictionary<string, List<T> > > DataBuilded { get; set; }

        public List<TResult> getCategoriesMost<TResult>(Func<T, TResult> selector)
        {
            if (DataBuilded.Count == 0) return new List<TResult>();

            return DataBuilded
                .FirstOrDefault()
                .Value
                .Keys
                .Cast<TResult>()
                .ToList();

        }

        public List<decimal> getCategriesDataInYear(int year, Func<T, decimal> keySelector)
        {
            List<decimal> seriesData = new List<decimal>();
            if(! DataBuilded.ContainsKey(year.ToString()) ) return new List<decimal>();

            //var categoryGroups = DataBuilded[year.ToString()]
            //    .Where(row => row.Key.Contains(keyWord));

            foreach (KeyValuePair<string , List<T> > category in DataBuilded[year.ToString()])
            {
                decimal categoryTotal = category.Value.Sum(keySelector);
                seriesData.Add(categoryTotal);
            }

            return seriesData
                .Select(row => decimal.Round(row, 0))
                .ToList();
        }

        public List<TResult> getCategoriesByWord<TResult>(string word, Func<T, TResult> keySelector)
        {
            return dataSource
                .Where(row => keySelector.Invoke(row).ToString().Contains(word))
                .Select(keySelector)
                .Distinct()
                .ToList();
        }

        public List<decimal> getCategoryDataByWordInYear(int year, List<string> categories, Func<T, decimal> dataSelector)
        {

            return categories
                .Select(row => DataBuilded[year.ToString()][row].Sum(dataSelector))
                .Select(row => decimal.Round(row, 0))
                .ToList();


        }

        public List<decimal> getCategoryYearData(int year, string category, Func<T, decimal> keySelector, Func<T, DateTime?> predicate = null)
        {
            if (! DataBuilded.ContainsKey(year.ToString())) return null;
            List<MonthGroupDataVM> yearData = DataBuilded[year.ToString()][category]
                .GroupBy(predicate, new monthCompare())
                .OrderBy(group => group.Key)
                .Select(group => new MonthGroupDataVM { groupSum = group.Sum(keySelector), groupKey = group.Key })
                .ToList();
            List<decimal> seriasData = new List<decimal>(12) { 0,0,0,0,0,0,0,0,0,0,0,0};

            foreach (MonthGroupDataVM monthSerias in yearData)
            {
                int? index = monthSerias.groupKey?.Month - 1;

                if(index != null)
                    seriasData[index?? 12] = monthSerias.groupSum;
            }
            return seriasData
                .Select(row => decimal.Round(row, 0))
                .ToList();
        }

        public List<CloudWord> getCloudWords(Func<T, object> categorySelector, Func<T, decimal> dataSelector)
        {
            return dataSource.GroupBy(categorySelector)
                .Select(group => new CloudWord {
                    name = group.Key.ToString(), 
                    weight = decimal.Round(group.Sum(dataSelector) , 0)
                })
                .ToList();
        }

        //public void buildDataSource<TKey1>( Func<T, TKey1> keySelector1, Func<T> keySelector2)
        //{
        //    DataBuilded = dataSource.GroupBy(keySelector1).Select(row => new YearGroupVM<T>()
        //    {
        //        Year = Convert.ToInt32(row.Key),
        //        categoryGroup = row.GroupBy(keySelector2).ToList()
        //    }).ToList<object>();
        //}

        public  void buildDataSource(Func<T, decimal> dataSelector, params Func<T, object>[] keySelector)
        {
            int index = -1;
            Dictionary<string ,int> categoriesOrder = getCloudWords(keySelector[1], dataSelector)
                .ToDictionary(row => row.name, row => index++);

            DataBuilded = dataSource.GroupBy(keySelector[0]).Select(row => new YearGroupVM<T>()
            {
                Year = Convert.ToInt32(row.Key ?? 0),
                categoryGroup = row
                .GroupBy(keySelector[1])
                .OrderByDescending(r => r.Key.ToString(), new CategoryComparer(categoriesOrder) )
                .ToDictionary(r => r.Key.ToString(), r => r.ToList() )
            })
            .OrderByDescending(row => row.Year)
            .ToDictionary(row => row.Year.ToString() , row => row.categoryGroup );


        }
        public List<string> getSubCategories(int year, string category)
        {
            return new List<string>() { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
        }
    }
}
