using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using Pens.WebUI.Models;

namespace Pens.WebUI.Controllers
{
    [Authorize]
    public class MKBController : Controller
    {

        public int pageSize = 10;
        MKBRepository mKBRepository = new MKBRepository();

        public ActionResult Index()
        {            
            return View();
        }

        public PartialViewResult PartialListMKB(string category = "")
        {
            MKBListView mkbView = new MKBListView
            {
                MKB = mKBRepository.MKB.Where(x => x.TitleEn.Contains(category)).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = pageSize,
                    TotalItems = mKBRepository.MKB.Where(x => x.TitleEn.Contains(category)).Count()
                }
            };

            List<string> alfabeta = mKBRepository.MKB.Select(x => x.TitleEn.Substring(0, 1)).Distinct().ToList();
            ViewBag.Category = category;
            ViewBag.Alfabeta = alfabeta;
            return PartialView(mkbView);
        }

        public PartialViewResult PartialDataListMKB(int page = 1, string category = "")
        {
            MKBListView mkbView = new MKBListView
            {
                MKB = mKBRepository.MKB.Where(x => x.TitleEn.Contains(category)).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = mKBRepository.MKB.Where(x => x.TitleEn.Contains(category)).Count()
                }
            };

            List<string> alfabeta = mKBRepository.MKB.Select(x => x.TitleEn.Substring(0, 1)).Distinct().ToList();
            ViewBag.Category = category;
            ViewBag.Alfabeta = alfabeta;
            return PartialView(mkbView);
        }
        
    }
}