using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using Pens.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Pens.WebUI.Controllers
{
    public class AccountController : Controller
    {
        UserRepository usersRepository = new UserRepository();

        [AllowAnonymous]

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        private bool ValidateUser(string login, string password)
        {
            bool isValid = false;



            Users user = usersRepository.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();

            if (user != null)
            {
                isValid = true;
            }
            
            return isValid;
        }
    }
}