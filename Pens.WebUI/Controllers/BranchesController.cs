using Pens.Domain.Abstract;
using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pens.WebUI.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class BranchesController : Controller
    {
        // GET: Branches
        public ActionResult Index()
        {
            var branches = BranchFacade.GetBranches();
            return View(branches);
        }

        public ActionResult Edit(long BranchID = 0)
        {
            Branch branch = BranchFacade.GetById(BranchID);
            if (branch != null)
            {
                return View(branch);
            }
            else
            {
                return View(new Branch());
            }
        }

        [HttpPost]
        public ActionResult Edit(Branch branch)
        {
            if (ModelState.IsValid)
            {
                BranchFacade.Save(branch);
                return Redirect("Index");
            }
            else
            {
                return View(branch);
            }
        }
                
        public ActionResult Delete(long BranchID = 0)
        {
            BranchFacade.Delete(BranchID);
            return Redirect("Index");
        }
    }
}