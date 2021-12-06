using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pens.WebUI.Models;
using Pens.Domain.Abstract;

namespace Pens.WebUI.Controllers
{
    [Authorize]
    public class MKBController : Controller
    {

        public int pageSize = 10;
       

        public ActionResult Index()
        {            
            return View();
        }

        public PartialViewResult PartialListMKB(string category = "")
        {
            MKBListView mkbView = new MKBListView
            {
                MKB = MKBFacade.GetByCategory(category, pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = pageSize,
                    TotalItems = MKBFacade.GetCount(category)
                }
            };

            List<string> alfabeta = MKBFacade.GetAlfabeta();
            ViewBag.Category = category;
            ViewBag.Alfabeta = alfabeta;
            return PartialView(mkbView);
        }

        public PartialViewResult PartialDataListMKB(int page = 1, string category = "")
        {
            MKBListView mkbView = new MKBListView
            {
                MKB = MKBFacade.GetByCategory(category, pageSize, page),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = MKBFacade.GetCount(category)
                }
            };

            List<string> alfabeta = MKBFacade.GetAlfabeta();
            ViewBag.Category = category;
            ViewBag.Alfabeta = alfabeta;
            return PartialView(mkbView);
        }
        
    }
}