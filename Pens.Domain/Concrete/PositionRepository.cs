using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Concrete
{
    public class PositionRepository
    {
        PensEntities context = new PensEntities();

        public IEnumerable<Positions> Positions
        {
            get { return context.Positions; }
        }
    }
}
