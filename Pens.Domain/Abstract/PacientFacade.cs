using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
    public class PacientFacade
    {
        static PacientsRepository pacientsRepository = new PacientsRepository();

        public static IEnumerable<Pacients> GetPacients(string seachText, int page, int pageSize) {
            return pacientsRepository.Pacients.Where(x => x.FIO.StartsWith(seachText, StringComparison.OrdinalIgnoreCase)).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static int GetPacientsCount(string seachText)
        {
            return pacientsRepository.Pacients.Where(x => x.FIO.StartsWith(seachText, StringComparison.OrdinalIgnoreCase)).Count();
        }

        public static Pacients GetById(long pacientId)
        {
            return pacientsRepository.GetById(pacientId);
        }

        public static void Save(Pacients pacient)
        {
            pacientsRepository.Save(pacient);
        }

        public static void Delete(long pacientId)
        {
            pacientsRepository.Delete(pacientId);
        }
        
    }
}
