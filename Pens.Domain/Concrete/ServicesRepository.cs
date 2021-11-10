using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Concrete
{
    public class ServicesRepository
    {
        PensEntities context = new PensEntities();

        public IEnumerable<Services> Services
        {
            get { return context.Services; }
        }

        public void Save(Services service)
        {
            if (service.ServiceID == 0)
                context.Services.Add(service);
            else
            {
                Services dbEntry = context.Services.Find(service.ServiceID);
                if (dbEntry != null)
                {
                    dbEntry.DocID = service.DocID;
                    dbEntry.PriceID = service.PriceID;
                    dbEntry.Kod = service.Kod;
                    dbEntry.Title = service.Title;
                    dbEntry.Cost = service.Cost;
                    dbEntry.CostR = service.CostR;
                    dbEntry.Quantity = service.Quantity;
                    dbEntry.BranchID = service.BranchID;
                }
            }
            context.SaveChanges();
        }

        public Services Delete(int serviceId)
        {
            Services dbEntry = context.Services.Find(serviceId);
            if (dbEntry != null)
            {
                context.Services.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void DeleteByDocId(long docId)
        {
            List<Services> dbEntryList = context.Services.Where(x => x.DocID == docId).ToList();
            if (dbEntryList != null)
            {
                foreach (var dbEntry in dbEntryList)
                {
                    context.Services.Remove(dbEntry);
                    
                }
                context.SaveChanges();
            }
        }

        public Services GetById(long id)
        {
            return context.Services.Where(x => x.ServiceID == id).FirstOrDefault();
        }
    }
}
