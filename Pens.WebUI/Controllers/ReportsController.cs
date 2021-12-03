using Pens.Domain.Abstract;
using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using Pens.Domain.Reports;
using Pens.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Pens.WebUI.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
                
        // GET: Reports
        public ActionResult Index()
        {
            Users user = UserFacade.GetUser(HttpContext.User.Identity.Name);
            ViewBag.Branch = new SelectList(BranchFacade.GetBranchesById(user.BranchId), "BranchID", "Title", user.BranchId);
            DocFilter docFilter = new DocFilter();
            ViewBag.docFilter = docFilter;
            return View();
        }

        [HttpPost]
        public ActionResult OpReport(DocFilter docFilter) 
        {
            Users user = UserFacade.GetUser(HttpContext.User.Identity.Name);
            ViewBag.Branch = new SelectList(BranchFacade.GetBranchesById(user.BranchId), "BranchID", "Title", user.BranchId);
            DateTime DateFrom = docFilter.dateFrom??DateTime.Now;
            DateTime DateTo = docFilter.dateTo??DateTime.Now;
            List<StatisticOperativDoc> statDocList = new List<StatisticOperativDoc>();
            List<Branch> branchList = BranchFacade.GetBranchesById(user.BranchId).ToList();
            foreach (var branch in branchList)
            {
                var docStat = DocFacade.GetDocs(docFilter.dateFrom, docFilter.dateTo, branch.BranchID);
                if (docStat.Count() > 0) {                  
                    statDocList.Add(new StatisticOperativDoc
                    {
                        BranchTitle = branch.Title,
                        NupPeople = docStat.Count(),
                        SummPrice = docStat.Sum(s => s.Services.Sum(su => su.Cost * su.Quantity)),
                        SummSeb = docStat.Sum(s => s.Services.Sum(su => su.CostR * su.Quantity)),
                        SummDif = docStat.Sum(s => s.Services.Sum(su => su.CostR * su.Quantity) - s.Services.Sum(su => su.Cost * su.Quantity)),
                        BranchDocs = docStat.ToList()

                    });
                }
               
            }

            return View(statDocList);
        }
    }


}