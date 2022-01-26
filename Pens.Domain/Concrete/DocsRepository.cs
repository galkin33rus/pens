using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pens.Domain.Concrete
{
    public class DocsRepository
    {
        PensEntities context = new PensEntities();

        public IEnumerable<Docs> Docs
        {
            get { return context.Docs.Include("Branch").Include("Services"); }
        }

        public void Save(Docs doc)
        {
            if (doc.DocID == 0)
                context.Docs.Add(doc);
            else
            {
                Docs dbEntry = context.Docs.Find(doc.DocID);
                if (dbEntry != null)
                {
                    dbEntry.DateDoc = doc.DateDoc;
                    dbEntry.FIO = doc.FIO;
                    dbEntry.Gender = doc.Gender;
                    dbEntry.DateBirth = doc.DateBirth;
                    dbEntry.Org = doc.Org;
                    dbEntry.Position = doc.Position;
                    dbEntry.Pasport = doc.Pasport;
                    dbEntry.StRod = doc.StRod;
                    dbEntry.FIORod = doc.FIORod;
                    dbEntry.NoTK = doc.NoTK;
                    dbEntry.KodMKB = doc.KodMKB.Trim();
                }
            }
            context.SaveChanges();
        }

        public Docs Delete(long docId)
        {
            Docs dbEntry = context.Docs.Find(docId);
            if (dbEntry != null)
            {
                context.Docs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Docs GetById(long DocID)
        {
            return context.Docs.Where(x => x.DocID == DocID).FirstOrDefault();
        }
    }
}
