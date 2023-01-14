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
            switch(index)
            {
                case 0:
                    serviceList[index].Service = new CourseDAService();
                    break;
                case 1:
                    serviceList[index].Service = new StudentDAService();
                    break;
                case 2:
                    serviceList[index].Service = new TeacherDAService();
                    break;
                case 3:
                    serviceList[index].Service = new GoodCourseDAService();
                    break;
            }

            return serviceList[index];
        }
        public static string getServiceTitle(int type)
        {
            return serviceList[type].ViewTitle;
        }
        public static IDiagramService getService(int type)
        {
            return serviceList[type].Service;
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