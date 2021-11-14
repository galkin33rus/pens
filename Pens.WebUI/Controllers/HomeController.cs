using Pens.WebUI.Classes;
using Pens.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pens.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            Report report = new Report();

            List<StatisticDoc> statDocList = report.GetStatisticTable(HttpContext.User.Identity.Name);
                                   
            return View(statDocList);
        }

                    
    }
}