using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Concrete
{
    public class PacientsRepository
    {
        PensEntities context = new PensEntities();

        public IEnumerable<Pacients> Pacients
        {
            get { return context.Pacients; }
        }

        public void Save(Pacients pacient)
        {
            if (pacient.PacientID == 0)
                context.Pacients.Add(pacient);
            else
            {
                Pacients dbEntry = context.Pacients.Find(pacient.PacientID);
                if (dbEntry != null)
                {                    
                    dbEntry.FIO = pacient.FIO;
                    dbEntry.Gender = pacient.Gender;
                    dbEntry.DateBirth = pacient.DateBirth;
                    dbEntry.OrgID = pacient.OrgID;
                    dbEntry.PositionID = pacient.PositionID;
                    dbEntry.Pasport = pacient.Pasport;
                    dbEntry.StRodID = pacient.StRodID;
                    dbEntry.FIORod = pacient.FIORod;
                    dbEntry.NoTK = pacient.NoTK;
                }
            }
            context.SaveChanges();
        }

        public Pacients Delete(long PacientID)
        {
            Pacients dbEntry = context.Pacients.Find(PacientID);
            if (dbEntry != null)
            {
                context.Pacients.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Pacients GetById(long PacientID)
        {
            return context.Pacients.Where(x => x.PacientID == PacientID).FirstOrDefault();
        }
    }
}
