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
        BranchRepository branchRepository = new BranchRepository();
        UserRepository userRepository = new UserRepository();
        DocsRepository docsRepository = new DocsRepository();
        // GET: Reports
        public ActionResult Index()
        {
            Users user = userRepository.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
            ViewBag.Branch = new SelectList(branchRepository.Branch.Where(x => x.BranchID == (user.BranchId ?? 0) || user.BranchId == null), "BranchID", "Title", user.BranchId);
            DocFilter docFilter = new DocFilter();
            ViewBag.docFilter = docFilter;
            return View();
        }

        [HttpPost]
        public ActionResult OpReport(DocFilter docFilter) 
        {
            Users user = userRepository.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();            
            ViewBag.Branch = new SelectList(branchRepository.Branch.Where(x => x.BranchID == (user.BranchId ?? 0) || user.BranchId == null), "BranchID", "Title", user.BranchId);
            DateTime DateFrom = docFilter.dateFrom??DateTime.Now;
            DateTime DateTo = docFilter.dateTo??DateTime.Now;
            List<StatisticOperativDoc> statDocList = new List<StatisticOperativDoc>();
            List<Branch> branchList = branchRepository.Branch.Where(x => x.BranchID == user.BranchId || user.BranchId == null).ToList();
            foreach (var branch in branchList)
            {
                var docStat = docsRepository.Docs.Where(x => x.DateDoc >= docFilter.dateFrom && x.DateDoc <= docFilter.dateTo && (x.BranchID == branch.BranchID));
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