using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DA.Interface
{
    public interface IDiagramBaseService<T> where T : class
    {
        //資料
        List<T> dataSource{ get; set; }

        void loadDataSource(DbSet<T> data, Func<T, bool> simplification);
        void buildDataSource(Func<T, decimal> dataSelector, params Func<T, object>[] keySelector);

        //主圖類項
        List<TResult> getCategoriesMost<TResult>(Func<T, TResult> selector);

        //主圖年單線資料
        List<decimal> getCategriesDataInYear(int year, Func<T, decimal> keySelector);

        //附圖年單線資料
        List<decimal> getCategoryYearData(int year, string category, Func<T, decimal> keySelector, Func<T, DateTime?> predicate = null);

        //雲圖項
        List<CloudWord> getCloudWords(Func<T, object> categorySelector, Func<T, decimal> dataSelector);

        List<string> getSubCategories(int year, string category);


    }
}
