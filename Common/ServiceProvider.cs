using DA.Interface;
using DA.Models;
using DA.Services;
using DA.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA.Common
{
    public static class ServiceProvider
    {

        private static string[] _keyWord { get; set; } = { null, null };

        private static List<ServiceSwitchModel> serviceList = new List<ServiceSwitchModel>()
        {

                    new ServiceSwitchModel
                    {
                        ViewTitle = "職能分析"
                    },
                    new ServiceSwitchModel
                    {
                        ViewTitle = "學員分析"
                    },
                    new ServiceSwitchModel
                    {
                        ViewTitle = "推薦分析"
                    },
                    new ServiceSwitchModel
                    {
                        ViewTitle = "推薦分析2",
                        getBigCategoriesService = BigCategoriesService.getGoodCourseBigCategories
                    },

        };

        public static ServiceSwitchModel getService(int index, params string[] keyWord)
        {
            keyWord.CopyTo(_keyWord, 0);
            switch(index)
            {
                case 0:
                    serviceList[index].Service = new CourseDAService(_keyWord[0]);
                    break;
                case 1:
                    serviceList[index].Service = new StudentDAService(_keyWord[0]);
                    break;
                case 2:
                    serviceList[index].Service = new TeacherDAService(_keyWord[0]);
                    break;
                case 3:
                    serviceList[index].Service = new GoodCourseDAService(_keyWord[0], _keyWord[1]);
                    break;
            }

            return serviceList[index];
        }
        public static string getServiceTitle(int type)
        {
            return serviceList[type].ViewTitle;
        }
        public static ServiceSwitchModel getInitService(int type)
        {
            return serviceList[type];
        }

        public static List<MenuVM> getMenu(user userInfo = null)
        {
            string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";

            if (userInfo is null)
            {
                int index = -1;
                return serviceList.Select((row) =>
                   new MenuVM
                   {
                       Name = row.ViewTitle,
                       Url = baseUrl+"DA/Index/" + (++index)

                   }).ToList();
            }
            else
            {
                return null;
            }


        }



    }
}