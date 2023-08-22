using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstract
{
    public interface IUserService
    {
        User GetByUsernameAndPassword(string username, string password);

        List<UserRoleItem> GetUserRoles(User user);
    }
}
