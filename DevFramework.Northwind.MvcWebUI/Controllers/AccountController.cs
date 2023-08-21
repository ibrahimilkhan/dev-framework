using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        public string Login()
        {
            AuthenticationHelper.CreateAuthCookie(
                new Guid(),
                "ibrahimilkhan",
                "ibrahimilkhan@hotmail.com",
                DateTime.Now.AddDays(15),
                new[] { "Admin" },
                false,
                "ibrahim",
                "oztürk");

            return "User has authenticated";
        }
    }
}