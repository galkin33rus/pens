using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pens.WebUI.HtmlHelpers
{
    public static class LoginHelper
    {

        public static MvcHtmlString UserName(string login)
        {
            Users user = new UserRepository().Users.Where(x => x.Login == login).FirstOrDefault();

            string userName = "";

            if (user != null)
            {
                userName = user.Name;
            }

            return MvcHtmlString.Create(userName);
        }
    }
}