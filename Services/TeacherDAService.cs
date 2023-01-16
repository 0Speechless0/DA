using DA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA.Interface;
using System.Text;

namespace DA.Services
{
    public class TeacherDAService : IDiagramService
    {

        public static Dictionary<int, Dictionary<int, string>> teacherMap = new Dictionary<int, Dictionary<int, string>>();
        public static Dictionary<int, int> viewTimeMap = new Dictionary<int, int>();

        static Func<course, string> getTeacherName = (row) =>
            teacherMap[row.LecturerType.Value][row.LecturerType.Value == 1 ? row.Lecturer.Value : row.OtherLecturer.Value];

        static Func<course, int> getCourseTotalView = (row) =>
            viewTimeMap.ContainsKey(row.Seq) ? viewTimeMap[row.Seq] : 0;
        IDiagramBaseService<course> _service;

        public TeacherDAService()
        {
            _service = new DiagramIn3YCourseBaseService<course>();
        }
        public void dataBuild(string[] searchWord)
        {

            using (ttqs_newEntities context = new ttqs_newEntities())
            {
                //teacher[2] 外部講師名稱字典 ；teacher[1]內部講師名稱字典
                teacherMap[2] = new Dictionary<int, string>();
                teacherMap[1] = new Dictionary<int, string>();


                foreach (var teacher in context.expert_data)
                {
                    teacherMap[2][teacher.Seq] = teacher.Name;
                }

                foreach (var teacher in context.user)
                {
                    teacherMap[1][teacher.UserSeq] = teacher.UserName;
                }
                viewTimeMap =
                    context.view_log
                    .GroupBy(row => row.CourseSeq)
                    .ToDictionary(row => row.Key, row => row.Sum(row2 => (int)(row2.ViewEndTime - row2.ViewStartTime)?.TotalHours));



                _service.loadDataSource(context.course, row => row.Lecturer != null && getTeacherName.Invoke(row).Contains(searchWord[0] ?? String.Empty));

            }

            _service.buildDataSource(
                row => getCourseTotalView.Invoke(row),
                row => getTeacherName.Invoke(row),
                row => row.CreatDate.Year.ToString(),
                row => row.CourseName
            );


        }
        public List<string> getCategories()
        {
            return _service.getCategoriesMost(row => getTeacherName.Invoke(row));
      
        }

        public List<decimal> getCategriesDataInYear(int year)
        {
            return _service.getCategriesDataInYear(year, row => getCourseTotalView.Invoke(row));
        }

        public List<decimal> getCategoryYearData(int year, string category)
        {
            return _service.getCategoryYearData(year, category, row => getCourseTotalView.Invoke(row));
        }

        public List<CloudWord> getCloudWords()
        {
            return _service.getCloudWordsV2(
                row => getCourseTotalView.Invoke(row)
            );
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