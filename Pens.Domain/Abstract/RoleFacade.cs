using Pens.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
    public class RoleFacade
    {

        static RoleRepository roleRepository = new RoleRepository();

        public static System.Collections.IEnumerable GetRoles()
        {
            return roleRepository.Roles;
        }
    }
}
