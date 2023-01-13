using DA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA.Models;
using DA.Services;
using DA.Common;
namespace DA.Controllers
{
    [remoteTokenAuthFilter]
    public class DAController : Controller
    {
        // GET: DA
        public ActionResult Index(int type)
        {
            ViewBag.Title = ServiceProvider.getServiceTitle(type);
            return View();
        } 



        public JsonResult getMainDiagramData(int type, string category = null, string bigCategory = null)
        {

            var service = ServiceProvider.getService(type, bigCategory, category).Service;
            int firstYear = DateTime.Now.Year;
            return Json(new
            {
                result = 0,
                xAxisCategories = service.getCategories(),
                wordCloud = service.getCloudWords(),
                series = new List<object>(3)
                {
                    new {
                        name  = firstYear,
                        data =service.getCategriesDataInYear(firstYear)
                    },
                    new {
                        name  = firstYear - 1,
                        data =service.getCategriesDataInYear(firstYear-1)
                    },
                    new {
                        name  = firstYear - 2,
                        data =service.getCategriesDataInYear(firstYear -2)
                    },
                }
            });
        }
        public JsonResult getSubDiagramData(int type, string category, string bigCategory=null)
        {
            var service = ServiceProvider.getService(type, bigCategory, category).Service;
            int firstYear = DateTime.Now.Year;
            return Json(new
            {
                result = 0,
                series = new List<object>(3)
                {
                    new {
                        name  = firstYear,
                        data =service.getCategoryYearData(firstYear, category)
                    },
                    new {
                        name  = firstYear - 1,
                        data =service.getCategoryYearData(firstYear-1, category)
                    },
                    new {
                        name  = firstYear - 2,
                        data =service.getCategoryYearData(firstYear -2, category)
                    },
                },
                xAxis = new List<List<string>>(3)
                {
                   service.getSubCategories(firstYear, category),
                   service.getSubCategories(firstYear-1, category),
                   service.getSubCategories(firstYear-2, category),
                }
                
            });

        }
        public JsonResult getBigCategories(int type)
        {
            var options = ServiceProvider.getInitService(type).getBigCategoriesService.Invoke();
            return Json(new
            {
                options = options
            });
        }
    }
}