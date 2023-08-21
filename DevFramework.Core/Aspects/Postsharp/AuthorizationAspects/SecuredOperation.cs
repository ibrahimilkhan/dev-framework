using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        public string Roles { get; set; }
        bool isAuthorized = false;

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');

            foreach (var role in roles)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(role))
                {
                    isAuthorized = true;
                }
            }

            if (isAuthorized == false)
            {
                throw new SecurityException("You are not authorized!");
            }
        }
    }
}
