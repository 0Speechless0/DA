using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DA.Interface;

namespace DA.Services
{
    public class StudentDAService : DiagramIn3YBaseService<view_history>, IDiagramService
    {
        public static Dictionary<int, string> studentNameMap = new Dictionary<int, string>();
        public StudentDAService(string searchWord) : base(
            dbset => dbset.view_history)
        { 
            using(ttqs_newEntities context = new ttqs_newEntities())
            {

                studentNameMap = context.user.ToDictionary(row => row.UserSeq, row => row.UserName);
            }
            dataSource = dataSource.Where(row => studentNameMap[row.UserSeq ].Contains(searchWord ?? String.Empty)).ToList();

            buildDataSource(
                row => row.ViewFinishTag,
                row => row.FristFinishTime?.Year, 
                row => studentNameMap[row.UserSeq] );

        }
        public List<string> getCategories(string word = "")
        {
            return getCategoriesMost(
                row => studentNameMap[row.CourseSeq])
                .ToList();
        }

        public List<decimal> getCategriesDataInYear(int year, string word = "")
        {
            return getCategriesDataInYear(year, row => row.ViewFinishTag);
                
        }

        public List<decimal> getCategoryYearData(int year, string category)
        {
            return getCategoryYearData(year, category, row => row.ViewFinishTag, row => row.FristFinishTime );
        }

        public List<CloudWord> getCloudWords()
        {
            return getCloudWords(
                row => studentNameMap[row.UserSeq],
                row => row.ViewFinishTag
            ).ToList();
        }


        public List<string> getBigCategories()
        {
            throw new NotImplementedException();
        }

    }
}