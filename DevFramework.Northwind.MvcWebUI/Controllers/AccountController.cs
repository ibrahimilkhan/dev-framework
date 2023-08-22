using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public string Login()
        {
            var user = _userService.GetByUsernameAndPassword("ibrahimilkhan", "123456");

            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                new Guid(),
                user.Username,
                user.Email,
                DateTime.Now.AddDays(15),
                _userService.GetUserRoles(user).Select(u => u.RoleName).ToArray(),
                false,
                user.FirstName,
                user.LastName);

                return "User has authenticated";
            }

            return "User is not authenticated!";
        }
    }
}