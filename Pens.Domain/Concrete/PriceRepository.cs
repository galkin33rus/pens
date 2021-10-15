using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Concrete
{
    public class PriceRepository
    {
        PensEntities context = new PensEntities();

        public IEnumerable<Price> Price
        {
            get { return context.Price; }
        }

        public void Save(Price price)
        {
            if (price.PriceID == 0)
                context.Price.Add(price);
            else
            {
                Price dbEntry = context.Price.Find(price.PriceID);
                if (dbEntry != null)
                {
                    dbEntry.Kod = price.Kod;
                    dbEntry.Title = price.Title;
                    dbEntry.Cost = price.Cost;
                    dbEntry.CostR = price.CostR;
                    dbEntry.BranchID = price.BranchID;                    
                }
            }
            context.SaveChanges();
        }

        public void Delete(long priceId)
        {
            Price dbEntry = context.Price.Find(priceId);
            if (dbEntry != null)
            {
                dbEntry.IsActive = false;
                context.SaveChanges();
            }            
        }

        public Price GetById(long id)
        {
            return context.Price.Where(x => x.PriceID == id).FirstOrDefault();
        }
    }
}
