using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{ 

    public class AuthenticationHelper
    {
        // Bu class ile yapılan: Kullanıcı bilgilerini al. ALdığın bilgileri şifrele. Şifrelenmiş bilgileri cookieye bas.
        public static void CreateAuthCookie(Guid id, string userName, string email, DateTime expiration, string[] roles, bool rememberMe, string firstName, string lastName)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe, CreateAuthTags(email, roles, firstName, lastName, id));

            string encTicker = FormsAuthentication.Encrypt(authTicket);

            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName));
        }

        private static string CreateAuthTags(string email, string[] roles, string firstName, string lastName, Guid id)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(email);
            stringBuilder.Append("|");

            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);

                if (i < roles.Length - 1)
                {
                    stringBuilder.Append(",");
                }
            }

            stringBuilder.Append('|');
            stringBuilder.Append(firstName);
            stringBuilder.Append("|");
            stringBuilder.Append(lastName);
            stringBuilder.Append("|");
            stringBuilder.Append(id);
            stringBuilder.Append("|");

            return stringBuilder.ToString();
        }
    }
}
