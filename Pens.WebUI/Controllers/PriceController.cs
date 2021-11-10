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
    public class PriceController : Controller
    {

        public int pageSize = 5;

        PriceRepository priceRepository = new PriceRepository();
        BranchRepository branchRepository = new BranchRepository();
        
        // GET: Price
        public ActionResult Index()
        {

            IEnumerable<Price> price = priceRepository.Price;
            if (User.IsInRole("Users"))
            {
                price = price.Where(x => x.IsActive);
            }
            return View(price);
        }

        public PartialViewResult GetPriceData(int page =1, string seachText = "")
        {
            PriceListView price = new PriceListView()
            {
                Price = priceRepository.Price.Where(x => x.IsActive && ( x.Title.ToUpper().Contains(seachText.ToUpper()) || x.Kod.StartsWith(seachText, StringComparison.OrdinalIgnoreCase))).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = priceRepository.Price.Where(x => x.IsActive && (x.Title.ToUpper().Contains(seachText.ToUpper()) || x.Kod.StartsWith(seachText, StringComparison.OrdinalIgnoreCase))).Count()
                }
            };

            ViewBag.Category = seachText;
            return PartialView(price);
        }

        public ActionResult Edit(long PriceId = 0)
        {
            Price price = priceRepository.GetById(PriceId);
            if (price != null)
            {
                ViewBag.Branch = new SelectList(branchRepository.Branch, "BranchID", "Title"); 
                return View(price);
            }
            else {
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Price price)
        {            
            if (ModelState.IsValid)
            {
                priceRepository.Save(price);
                return Redirect("Index");
            }
            else {
                ViewBag.Branch = new SelectList(branchRepository.Branch, "BranchID", "Title"); 
                return View(price);
            }
        }

        public ActionResult Create()
        {
            Price price = new Price();            
            ViewBag.Branch = new SelectList(branchRepository.Branch, "BranchID", "Title"); 
            return View("Edit", price);
        }

        public ActionResult Delete(long PriceID = 0)
        {            
            priceRepository.Delete(PriceID);
            return Redirect("Index");
        }

        public JsonResult GetPriceDataJson(long Id = 0)
        {
            Price price = priceRepository.GetById(Id);
            return Json(new
            {
                priceID = price.PriceID,
                kod = price.Kod,
                cost = price.Cost,
                costR = price.CostR,
                title = price.Title,                
                branchID = price.BranchID
            }, JsonRequestBehavior.AllowGet);
        }
    }
}