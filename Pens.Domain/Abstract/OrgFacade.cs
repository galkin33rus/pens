using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
    public class OrgFacade
    {
        static OrgRepository orgRepository = new OrgRepository();

        public static IEnumerable<Organizations> GetOrganizations()
        {
            return orgRepository.Org;
        }
    }
}
