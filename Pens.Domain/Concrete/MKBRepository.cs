using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Concrete
{
    public class MKBRepository
    {
        PensEntities context = new PensEntities();

        public IEnumerable<MKB> MKB
        {
            get { return context.MKB; }
        }
    }
}
