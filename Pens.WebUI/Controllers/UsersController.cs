using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pens.Domain.Entities;
using Pens.Domain.Abstract;

namespace Pens.WebUI.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UsersController : Controller
    {
        
        // GET: Users
        public ActionResult Index()
        {
            var users = UserFacade.GetUsers();
            return View(users.ToList());
        }
               
        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(BranchFacade.GetBranches(), "BranchID", "Title");
            ViewBag.RoleId = new SelectList(RoleFacade.GetRoles(), "Id", "Name");
            return View();
        }

        // POST: Users/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Login,Password,Position,BranchId,RoleId")] Users users)
        {
            if (ModelState.IsValid)
            {
                UserFacade.Save(users);
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(BranchFacade.GetBranches(), "BranchID", "Title", users.BranchId);
            ViewBag.RoleId = new SelectList(RoleFacade.GetRoles(), "Id", "Name", users.RoleId);
            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = UserFacade.GetById((int)id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(BranchFacade.GetBranches(), "BranchID", "Title", users.BranchId);
            ViewBag.RoleId = new SelectList(RoleFacade.GetRoles(), "Id", "Name", users.RoleId);
            return View(users);
        }

        // POST: Users/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Login,Password,Position,BranchId,RoleId")] Users users)
        {
            if (ModelState.IsValid)
            {
                UserFacade.Save(users);
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(BranchFacade.GetBranches(), "BranchID", "Title", users.BranchId);
            ViewBag.RoleId = new SelectList(RoleFacade.GetRoles(), "Id", "Name", users.RoleId);
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
            Users users = UserFacade.GetById((int)id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users user = UserFacade.GetUser(HttpContext.User.Identity.Name);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == user.Id) {
                Users deleteUser = UserFacade.GetById(id);
                ViewBag.Message = "Удаление текущего пользователя невозможно.";
                return View(deleteUser);    
            }
            UserFacade.Delete(id);
            return RedirectToAction("Index");                
        }

    }
}
