using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DA.Interface;

namespace DA.Services
{
    public class StudentDAService : IDiagramService
    {
        public static Dictionary<int, string> studentNameMap = new Dictionary<int, string>();

        IDiagramBaseService<view_history> _service;

       
        public StudentDAService()
        {
            _service = new DiagramIn3YBaseService<view_history>();
        }
        public void dataBuild(string[] searchWord)
        {

            using (ttqs_newEntities context = new ttqs_newEntities())
            {

                studentNameMap = context.user.ToDictionary(row => row.UserSeq, row => row.UserName);
                _service.loadDataSource(context.view_history, row => studentNameMap[row.UserSeq].Contains(searchWord[1] ?? String.Empty));
            }

            _service.buildDataSource(
                row => row.ViewFinishTag,
                row => row.FristFinishTime?.Year,
                row => studentNameMap[row.UserSeq]);

        }
        public List<string> getCategories()
        {
            return _service.getCategoriesMost(
                row => studentNameMap[row.CourseSeq])
                .ToList();
        }

        public List<decimal> getCategriesDataInYear(int year)
        {
            return _service.getCategriesDataInYear(year, row => row.ViewFinishTag);
                
        }

        public List<decimal> getCategoryYearData(int year, string category)
        {
            return _service.getCategoryYearData(year, category, row => row.ViewFinishTag, row => row.FristFinishTime );
        }

        public List<CloudWord> getCloudWords()
        {
            return _service.getCloudWords(
                row => studentNameMap[row.UserSeq],
                row => row.ViewFinishTag
            ).ToList();
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