using Pens.Domain.Concrete;
using Pens.Domain.Entities;
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
        DocsRepository docsRepository = new DocsRepository();
        UserRepository userRepository = new UserRepository();
        BranchRepository branchRepository = new BranchRepository(); 
        // GET: Home
        public ActionResult Index()
        {
            Users user = userRepository.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
            DocFilter docFilter = new DocFilter();
            List<StatisticDoc> statDocList = new List<StatisticDoc>();
            List<Branch> branchList = branchRepository.Branch.Where(x => x.BranchID == user.BranchId || user.BranchId == null).ToList();
            foreach (var branch in branchList)
            {
                var  docStat = docsRepository.Docs.Where(x => x.DateDoc >= docFilter.dateFrom && x.DateDoc <= docFilter.dateTo && (x.BranchID == branch.BranchID));
                statDocList.Add(new StatisticDoc
                {
                    BranchTitle = branch.Title,
                    NupPeople = docStat.Count(),
                    SummPrice = docStat.Sum(s => s.Services.Sum(su => su.Cost * su.Quantity)),
                    SummSeb = docStat.Sum(s => s.Services.Sum(su => su.CostR * su.Quantity)),
                    SummDif = docStat.Sum(s => s.Services.Sum(su => su.CostR * su.Quantity) - s.Services.Sum(su => su.Cost * su.Quantity))
                });
            }
                                   
            return View(statDocList);
        }
    }
}