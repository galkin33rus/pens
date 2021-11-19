using Pens.Domain.Abstract;
using Pens.Domain.Concrete;
using Pens.Domain.Entities;
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
    public class PacientsController : Controller
    {
        public int pageSize = 10;
    
        
        
        

        public ActionResult Index(string seachText = "", int page = 1)
        {
            PacientsListView pacients = PacientsListViewBuilder.GetPacientsListView(seachText, page, pageSize);
            return View(pacients);
        }

        public PartialViewResult GetPacientsData(string seachText = "", int page = 1 )
        {
            PacientsListView pacients = PacientsListViewBuilder.GetPacientsListView(seachText, page, pageSize);
            return PartialView(pacients);
        }

        public PartialViewResult PatienPartitalList(string seachText = "", int page = 1)
        {
            PacientsListView pacients = PacientsListViewBuilder.GetPacientsListView(seachText, page, pageSize);
            return PartialView(pacients);
        }

               

        public ActionResult Edit(long PacientID)
        {
            Pacients pacient = PacientFacade.GetById(PacientID);
            if (pacient != null)
            {
                FillViewBag();
                return View(pacient);
            }
            else
            {
                return View("Index");
            }
        }

        
        [HttpPost]        
        public ActionResult Edit(Pacients pacient)
        {
            if (ModelState.IsValid)
            {
                PacientFacade.Save(pacient);
                return Json(new { Success = true });
            }
            else
            {
                FillViewBag();
                return PartialView("Partial", pacient);
            }
        }

        public ActionResult Create()
        {
            FillViewBag();
            return View("Edit", new Pacients());
        }

        public ActionResult Delete(long PacientID)
        {
            Pacients pacient = PacientFacade.GetById(PacientID);
            if (pacient != null)
            {
                PacientFacade.Delete(PacientID);
            }
            return Redirect("Index");
        }

        public JsonResult GetPacientDataJson(long Id = 1)
        {
            Pacients pacient = PacientFacade.GetById(Id);
            return Json(new {
                fio = pacient.FIO,
                dateBirth = pacient.DateBirth.ToShortDateString(),
                gender= pacient.Gender,
                org = pacient.Organizations.Title,
                position = pacient.Positions.Title,
                pasport = pacient.Pasport,
                noTk = pacient.NoTK,
                stRod = (pacient.StRod != null)?pacient.StRod.Title:"",
                fioRod = pacient.FIORod}, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Partial(long PacientID = -1)
        {
            Pacients pacient = PacientFacade.GetById(PacientID);
            FillViewBag();
            if (pacient != null)
            {

                return PartialView(pacient);
            }
            else
            {
                return PartialView(new Pacients());
            }
        }

        private void FillViewBag()
        {
            ViewBag.Branch = new SelectList(BranchFacade.GetBranches(), "BranchID", "Title");
            ViewBag.Gender = new string[] { "", "М", "Ж" };
            ViewBag.Position = new SelectList(PositionFacade.GetPositions(), "PositionID", "Title");
            ViewBag.StRod = new SelectList(StRodFacade.GetStRods(), "StRodID", "Title");
            ViewBag.Org = new SelectList(OrgFacade.GetOrganizations(), "OrgID", "Title");
        }
    }
}