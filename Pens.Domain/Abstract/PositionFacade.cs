using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
    public class PositionFacade
    {

        private static PositionRepository positionRepository = new PositionRepository();

        public static IEnumerable<Positions> GetPositions()
        {
            return positionRepository.Positions;
        }
    }
}
