using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Interface
{
    /// <summary>
    /// 該介面用於智慧商情模組一般化分析頁的資料串接
    /// </summary>
    public interface IDiagramService 
    {


        /// <summary>
        /// 取得表單橫項之項目標題
        /// </summary>
        /// <returns>表單橫項之項目</returns>
        List<string> getCategories();


        /// <summary>
        /// 取得某年度之表單縱項之項目資料
        /// </summary>
        /// <param name="year">西元年</param>
        /// <returns>某年度表單縱向資料清單</returns>
        List<decimal> getCategriesDataInYear(int year);

        /// <summary>
        /// 取得某年度的類別衍生出的表單縱項之項目資料
        /// </summary>
        /// <param name="year">西元年</param>
        /// <param name="category">類別</param>
        /// <returns>某年度的類別衍生表單縱向資料清單</returns>
        List<decimal> getCategoryYearData(int year, string category);

        /// <summary>
        /// 取得雲字資料
        /// </summary>
        /// <returns>雲字資料清單</returns>
        List<CloudWord> getCloudWords();

        /// <summary>
        /// 取得某年度的類別衍生出的表單橫向項之項目標題
        /// </summary>
        /// <returns>衍生出的表單橫向項之項目標題清單</returns>
        List<string> getSubCategories(int year, string category);

        List<string> getBigCategories();

        void dataBuild(params string[] searchWord);

    }
}
