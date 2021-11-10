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
    public class PacientsController : Controller
    {
        public int pageSize = 10;

        PacientsRepository pacientsRepository = new PacientsRepository();
        BranchRepository branchRepository = new BranchRepository();
        PositionRepository positionRepository = new PositionRepository();
        StRodRepository stRodRepository = new StRodRepository();
        OrgRepository orgRepository = new OrgRepository();

        public ActionResult Index(string seachText = "", int page = 1)
        {
            PacientsListView pacients = new PacientsListView()
            {
                Pacients = pacientsRepository.Pacients.Where(x => x.FIO.StartsWith(seachText, StringComparison.OrdinalIgnoreCase)).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = pacientsRepository.Pacients.Where(x => x.FIO.StartsWith(seachText, StringComparison.OrdinalIgnoreCase)).Count()
                }
            };
            return View(pacients);
        }

        public PartialViewResult GetPacientsData(string seachText = "", int page = 1 )
        {
            PacientsListView pacients = new PacientsListView()
            {
                Pacients = pacientsRepository.Pacients.Where(x => x.FIO.StartsWith(seachText, StringComparison.OrdinalIgnoreCase)).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = pacientsRepository.Pacients.Where(x => x.FIO.StartsWith(seachText, StringComparison.OrdinalIgnoreCase)).Count()
                }
            };
            return PartialView(pacients);
        }

        public PartialViewResult PatienPartitalList(string seachText = "", int page = 1)
        {
            PacientsListView pacients = new PacientsListView()
            {
                Pacients = pacientsRepository.Pacients.Where(x => x.FIO.StartsWith(seachText, StringComparison.OrdinalIgnoreCase)).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = pacientsRepository.Pacients.Where(x => x.FIO.StartsWith(seachText, StringComparison.OrdinalIgnoreCase)).Count()
                }
            };
            return PartialView(pacients);
        }
        

        public ActionResult Edit(long PacientID)
        {
            Pacients pacient = pacientsRepository.GetById(PacientID);
            if (pacient != null)
            {
                ViewBag.Branch = new SelectList(branchRepository.Branch, "BranchID", "Title");
                ViewBag.Gender = new string[] { "", "М", "Ж" };
                ViewBag.Position = new SelectList(positionRepository.Positions, "PositionID", "Title");
                ViewBag.StRod = new SelectList(stRodRepository.StRod, "StRodID", "Title");
                ViewBag.Org = new SelectList(orgRepository.Org , "OrgID", "Title");
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
                pacientsRepository.Save(pacient);
                return Json(new { Success = true });
            }
            else
            {
                //return Json(new { Success = false });
                ViewBag.Branch = new SelectList(branchRepository.Branch, "BranchID", "Title");
                ViewBag.Gender = new string[] { "", "М", "Ж" };
                ViewBag.Position = new SelectList(positionRepository.Positions, "PositionID", "Title");
                ViewBag.StRod = new SelectList(stRodRepository.StRod, "StRodID", "Title");
                ViewBag.Org = new SelectList(orgRepository.Org, "OrgID", "Title");
                return PartialView("Partial", pacient);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Branch = new SelectList(branchRepository.Branch, "BranchID", "Title");
            ViewBag.Gender = new string[] { "", "М", "Ж" };
            ViewBag.Position = new SelectList(positionRepository.Positions, "PositionID", "Title");
            ViewBag.StRod = new SelectList(stRodRepository.StRod, "StRodID", "Title");
            ViewBag.Org = new SelectList(orgRepository.Org, "OrgID", "Title");
            return View("Edit", new Pacients());
        }

        public ActionResult Delete(long PacientID)
        {
            Pacients pacient = pacientsRepository.GetById(PacientID);
            if (pacient != null)
            {
                pacientsRepository.Delete(PacientID);
            }
            return Redirect("Index");
        }

        public JsonResult GetPacientDataJson(long Id = 1)
        {
            Pacients pacient = pacientsRepository.GetById(Id);
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
            Pacients pacient = pacientsRepository.GetById(PacientID);
            ViewBag.Branch = new SelectList(branchRepository.Branch, "BranchID", "Title");
            ViewBag.Gender = new string[] { "", "М", "Ж" };
            ViewBag.Position = new SelectList(positionRepository.Positions, "PositionID", "Title");
            ViewBag.StRod = new SelectList(stRodRepository.StRod, "StRodID", "Title");
            ViewBag.Org = new SelectList(orgRepository.Org, "OrgID", "Title");
            if (pacient != null)
            {

                return PartialView(pacient);
            }
            else
            {
                return PartialView(new Pacients());
            }
        }
    }
}