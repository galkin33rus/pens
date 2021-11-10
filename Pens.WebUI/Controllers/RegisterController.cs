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
    public class RegisterController : Controller
    {
        DocsRepository docsRepository = new DocsRepository();
        BranchRepository branchRepository = new BranchRepository();
        PositionRepository positionRepository = new PositionRepository();
        StRodRepository stRodRepository = new StRodRepository();
        OrgRepository orgRepository = new OrgRepository();
        ServicesRepository servicesRepository = new ServicesRepository();
        PriceRepository priceRepository = new PriceRepository();
        UserRepository userRepository = new UserRepository();

        public int pageSize = 50;
        
        public ActionResult Index(int page = 1)
        {
            Users user = userRepository.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
            DateTime dt = DateTime.Now;
            ViewBag.Branch = new SelectList(branchRepository.Branch.Where(x => x.BranchID == (user.BranchId ?? 0) || user.BranchId == null), "BranchID", "Title", user.BranchId);
            DocFilter docFilter = new DocFilter();  
            ViewBag.docFilter = docFilter;
            docFilter.BranchID = user.BranchId;
            IEnumerable<Docs> docs = docsRepository.Docs.Where(x => x.DateDoc >= docFilter.dateFrom && x.DateDoc <= docFilter.dateTo && (x.BranchID == user.BranchId || user.BranchId == null));
            return View(docs);
        }

        [HttpPost]
        public ActionResult Index(DocFilter docFilter)
        {
            Users user = userRepository.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
            DateTime dt = DateTime.Now;
            if (docFilter.dateFrom == null) { docFilter.dateFrom = new DateTime(dt.Year, dt.Month, 1); }
            if (docFilter.dateTo == null) { docFilter.dateTo = ((DateTime)docFilter.dateFrom).AddMonths(1).AddDays(-1); }
            IEnumerable<Docs> docs = docsRepository.Docs.Where(x => x.DateDoc >= docFilter.dateFrom && x.DateDoc <= docFilter.dateTo);
            if (docFilter.BranchID != null && docFilter.BranchID > 0) {
                docs = docs.Where(x => x.BranchID == docFilter.BranchID);
            }
            ViewBag.Branch = new SelectList(branchRepository.Branch.Where(x => x.BranchID == (user.BranchId ?? 0) || user.BranchId == null), "BranchID", "Title", docFilter.BranchID);
            ViewBag.docFilter = docFilter;
            return View(docs);
        }

        public ActionResult Edit(long DocID)
        {
            Users user = userRepository.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
            Docs doc = docsRepository.GetById(DocID);
            if (doc != null)
            {
                ViewBag.Branch = new SelectList(branchRepository.Branch.Where(x => x.BranchID == (user.BranchId ?? 0) || user.BranchId == null), "BranchID", "Title", user.BranchId);
                ViewBag.Gender = new string[] { "", "М", "Ж" };
                ViewBag.Position = new SelectList(positionRepository.Positions, "PositionID", "Title");
                ViewBag.StRod = new SelectList(stRodRepository.StRod, "StRodID", "Title");
                ViewBag.Org = new SelectList(orgRepository.Org, "OrgID", "Title");             
                return View(doc);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Docs doc)
        {
            List<Services> _services = new List<Services>();
            if (ModelState.IsValid)
            {
                
                foreach (Services service in doc.Services)
                {
                    if (service.PriceID > 0 && service.Quantity > 0)
                    {
                        Services _service = new Services();
                        Price p = priceRepository.GetById(service.PriceID);
                        _service.PriceID = p.PriceID;
                        _service.Kod = p.Kod;
                        _service.Cost = p.Cost;
                        _service.CostR = p.CostR;
                        _service.Title = p.Title;
                        _service.BranchID = p.BranchID;
                        _service.Quantity = service.Quantity;                        
                        _services.Add(_service);
                    }
                }
                doc.Services = null;
                docsRepository.Save(doc);
                servicesRepository.DeleteByDocId(doc.DocID);
                foreach (Services s in _services)
                {
                    s.DocID = doc.DocID;
                    servicesRepository.Save(s);
                }
                
                return Redirect("Index");
            }
            else
            {
                //doc.Services = _services;
                Users user = userRepository.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
                ViewBag.Branch = new SelectList(branchRepository.Branch.Where(x => x.BranchID == (user.BranchId ?? 0) || user.BranchId == null), "BranchID", "Title", user.BranchId);
                ViewBag.Gender = new string[] { "", "М", "Ж" };
                ViewBag.Position = new SelectList(positionRepository.Positions, "PositionID", "Title");
                ViewBag.StRod = new SelectList(stRodRepository.StRod, "StRodID", "Title");
                ViewBag.Org = new SelectList(orgRepository.Org, "OrgID", "Title");
                return View(doc);
            }
        }

        public ActionResult Create()
        {
            Users user = userRepository.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
            ViewBag.Branch = new SelectList(branchRepository.Branch.Where(x => x.BranchID == (user.BranchId ?? 0) || user.BranchId == null), "BranchID", "Title", user.BranchId);
            ViewBag.Gender = new string[] { "", "М", "Ж" };
            ViewBag.Position = new SelectList(positionRepository.Positions, "PositionID", "Title");
            ViewBag.StRod = new SelectList(stRodRepository.StRod, "StRodID", "Title");
            ViewBag.Org = new SelectList(orgRepository.Org, "OrgID", "Title");
            return View("Edit", new Docs() { Date = DateTime.Now, DateDoc = DateTime.Now, BranchID  = user.BranchId??0 });
        }

        public ActionResult Delete(long DocId)
        {
            Docs doc = docsRepository.GetById(DocId);
            if (doc != null) {
                docsRepository.Delete(DocId);
            }
            return Redirect("Index");
        }
    }
}