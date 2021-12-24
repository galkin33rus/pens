using Pens.Domain.Abstract;
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
       
        public int pageSize = 50;
        
        public ActionResult Index(int page = 1)
        {
            Users user = UserFacade.GetUser(HttpContext.User.Identity.Name); 
            DateTime dt = DateTime.Now;
            ViewBag.Branch = new SelectList(BranchFacade.GetBranchesById(user.BranchId), "BranchID", "Title", user.BranchId);
            DocFilter docFilter = new DocFilter();  
            ViewBag.docFilter = docFilter;
            docFilter.BranchID = user.BranchId;
            IEnumerable<Docs> docs = DocFacade.GetDocs(docFilter.DateFrom, docFilter.DateTo, user.BranchId);
            return View(docs);
        }

        [HttpPost]
        public ActionResult Index(DocFilter docFilter)
        {
            Users user = UserFacade.GetUser(HttpContext.User.Identity.Name); 
            DateTime dt = DateTime.Now;
            if (docFilter.DateFrom == null) { docFilter.DateFrom = new DateTime(dt.Year, dt.Month, 1); }
            if (docFilter.DateTo == null) { docFilter.DateTo = ((DateTime)docFilter.DateFrom).AddMonths(1).AddDays(-1); }
            IEnumerable<Docs> docs = DocFacade.GetDocs(docFilter.DateFrom, docFilter.DateTo);
            if (docFilter.BranchID != null && docFilter.BranchID > 0) {
                docs = docs.Where(x => x.BranchID == docFilter.BranchID);
            }
            ViewBag.Branch = new SelectList(BranchFacade.GetBranchesById(user.BranchId), "BranchID", "Title", docFilter.BranchID);
            ViewBag.docFilter = docFilter;
            return View(docs);
        }

        public ActionResult Edit(long DocID)
        {
            Users user = UserFacade.GetUser(HttpContext.User.Identity.Name);
            Docs doc = DocFacade.GetById(DocID);
            if (doc != null)
            {
                ViewBag.Branch = new SelectList(BranchFacade.GetBranchesById(user.BranchId), "BranchID", "Title", user.BranchId);
                ViewBag.Gender = new string[] { "", "М", "Ж" };
                ViewBag.Position = new SelectList(PositionFacade.GetPositions(), "PositionID", "Title");
                ViewBag.StRod = new SelectList(StRodFacade.GetStRods(), "StRodID", "Title");
                ViewBag.Org = new SelectList(OrgFacade.GetOrganizations(), "OrgID", "Title");             
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
                        Price p = PriceFacade.GetById(service.PriceID);
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
                DocFacade.Save(doc);
                ServiceFacade.DeleteByDocId(doc.DocID);
                foreach (Services s in _services)
                {
                    s.DocID = doc.DocID;
                    ServiceFacade.Save(s);
                }
                
                return Redirect("Index");
            }
            else
            {
                //doc.Services = _services;
                Users user = UserFacade.GetUser(HttpContext.User.Identity.Name);
                ViewBag.Branch = new SelectList(BranchFacade.GetBranchesById(user.BranchId), "BranchID", "Title", user.BranchId);
                ViewBag.Gender = new string[] { "", "М", "Ж" };
                ViewBag.Position = new SelectList(PositionFacade.GetPositions(), "PositionID", "Title");
                ViewBag.StRod = new SelectList(StRodFacade.GetStRods(), "StRodID", "Title");
                ViewBag.Org = new SelectList(OrgFacade.GetOrganizations(), "OrgID", "Title");
                return View(doc);
            }
        }

        public ActionResult Create()
        {
            Users user = UserFacade.GetUser(HttpContext.User.Identity.Name);
            ViewBag.Branch = new SelectList(BranchFacade.GetBranchesById(user.BranchId), "BranchID", "Title", user.BranchId);
            ViewBag.Gender = new string[] { "", "М", "Ж" };
            ViewBag.Position = new SelectList(PositionFacade.GetPositions(), "PositionID", "Title");
            ViewBag.StRod = new SelectList(StRodFacade.GetStRods(), "StRodID", "Title");
            ViewBag.Org = new SelectList(OrgFacade.GetOrganizations(), "OrgID", "Title");
            return View("Edit", new Docs() { Date = DateTime.Now, DateDoc = DateTime.Now, BranchID  = user.BranchId??0 });
        }

        public ActionResult Delete(long docId)
        {
            Docs doc = DocFacade.GetById(docId);
            if (doc != null) {
                DocFacade.Delete(docId);
            }
            return Redirect("Index");
        }
    }
}