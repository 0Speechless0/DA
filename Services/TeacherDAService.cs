using DA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA.Interface;
using System.Text;

namespace DA.Services
{
    public class TeacherDAService : DiagramIn3YCourseBaseService<course> , IDiagramService
    {

        public static Dictionary<int, string> teacherMap = new Dictionary<int, string>();
        public static Dictionary<int, int> viewTimeMap = new Dictionary<int, int>();
        public TeacherDAService(string searchTeacher):base(db => db.course,
            row => row.Lecturer != null && teacherMap[row.Seq].Contains(searchTeacher ?? String.Empty))
        {
            using(ttqs_newEntities context = new ttqs_newEntities() )
            {
                foreach(var teacher in context.expert_data)
                {
                    teacherMap[teacher.Seq] = teacher.Name;
                }

                foreach(var viewlog in context.view_log)
                {
                    if (!viewTimeMap.ContainsKey(viewlog.CourseSeq)) viewTimeMap[viewlog.CourseSeq] = 0;
                    viewTimeMap[viewlog.CourseSeq] += (int)(viewlog.ViewEndTime - viewlog.ViewStartTime)?.TotalHours;
                }
                
            }
            buildDataSource(
                row => viewTimeMap[row.Seq],
                row => teacherMap[row.Lecturer.Value],
                row => row.CreatDate.Year.ToString(),
                row => row.Seq
            );
        }
        public List<string> getCategories(string word = "")
        {
            return base.getCategoriesMost(row => teacherMap[row.Seq])
                .Select(row =>
                {
                    StringBuilder sb = new StringBuilder(row);
                    sb[1] = '*';
                    return sb.ToString();
                }).ToList();
        }

        public List<decimal> getCategriesDataInYear(int year, string word = "")
        {
            return base.getCategriesDataInYear(year, row => viewTimeMap[row.Seq]);
        }

        public List<decimal> getCategoryYearData(int year, string category)
        {
            return getCategoryYearData(year, category, row => viewTimeMap[row.Seq]);
        }

        public List<CloudWord> getCloudWords()
        {
            return base.getCloudWords(
                row => viewTimeMap[row.Seq]
            );
        }


        public List<string> getBigCategories()
        {
            throw new NotImplementedException();
        }
    }
}