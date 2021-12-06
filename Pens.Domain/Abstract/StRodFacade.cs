using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
    public class StRodFacade
    {
        static StRodRepository stRodRepository = new StRodRepository();

        public static IEnumerable<StRod> GetStRods()
        {
            return stRodRepository.StRod;
        }
    }
}
