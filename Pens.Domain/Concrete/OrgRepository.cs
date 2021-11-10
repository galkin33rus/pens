using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Concrete
{
    public class OrgRepository
    {
        PensEntities context = new PensEntities();

        public IEnumerable<Organizations> Org
        {
            get { return context.Organizations; }
        }
    }
}
