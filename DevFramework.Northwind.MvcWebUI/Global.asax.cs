using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Core.Utilities.Mvc.Infrastructure;
using DevFramework.Northwind.Business.DependencyResolver.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace DevFramework.Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
        }
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }
        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        
        {
            try
            {
                var authCode = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCode != null)
                {
                    var encTicket = authCode.Value;

                    if (!String.IsNullOrEmpty(encTicket))
                    {
                        var ticket = FormsAuthentication.Decrypt(encTicket);
                        var securityUtilities = new SecurityUtilities();
                        var identity = securityUtilities.FormsAuthTicketToIdentity(ticket);
                        var principal = new GenericPrincipal(identity, identity.Roles);

                        HttpContext.Current.User = principal;
                        Thread.CurrentPrincipal = principal;  //backend taraf�nda da eri�im sa�layabilmek i�in yazildi

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}