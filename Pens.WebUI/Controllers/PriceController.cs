using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using Pens.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pens.Domain.Abstract;

namespace Pens.WebUI.Controllers
{
    [Authorize]
    public class PriceController : Controller
    {

        public int pageSize = 5;

        
        
        // GET: Price
        public ActionResult Index()
        {
            IEnumerable<Price> price = PriceFacade.GetPrice();

            if (User.IsInRole("Users"))
            {
                price = PriceFacade.GetActivePrice();
            }
            return View(price);
        }

        public PartialViewResult GetPriceData(int page =1, string seachText = "")
        {
            PriceListView price = new PriceListView()
            {
                Price = PriceFacade.GetSearchText(seachText, pageSize, page),                
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = PriceFacade.GetTotalItems(seachText)
                }
            };

            ViewBag.Category = seachText;
            return PartialView(price);
        }

        public ActionResult Edit(long PriceId = 0)
        {
            Price price = PriceFacade.GetById(PriceId);
            if (price != null)
            {
                ViewBag.Branch = new SelectList(BranchFacade.GetBranches(), "BranchID", "Title"); 
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
                PriceFacade.Save(price);
                return Redirect("Index");
            }
            else {
                ViewBag.Branch = new SelectList(BranchFacade.GetBranches(), "BranchID", "Title"); 
                return View(price);
            }
        }

        public ActionResult Create()
        {
            Price price = new Price();
            ViewBag.Branch = new SelectList(BranchFacade.GetBranches(), "BranchID", "Title"); 
            return View("Edit", price);
        }

        public ActionResult Delete(long PriceID = 0)
        {
            PriceFacade.Delete(PriceID);
            return Redirect("Index");
        }

        public JsonResult GetPriceDataJson(long Id = 0)
        {
            Price price = PriceFacade.GetById(Id);
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