using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Concrete
{
    public class BranchRepository
    {
        PensEntities context = new PensEntities();

        public IEnumerable<Branch> Branch
        {
            get { return context.Branch; }
        }

        public void Save(Branch branch)
        {
            if (branch.BranchID == 0)
                context.Branch.Add(branch);
            else
            {
                Price dbEntry = context.Price.Find(branch.BranchID);
                if (dbEntry != null)
                {                    
                    dbEntry.Title = branch.Title;                  
                }
            }
            context.SaveChanges();
        }

        public void Delete(long BranchID)
        {
            Branch dbEntry = context.Branch.Find(BranchID);
            if (dbEntry != null)
            {
                context.Branch.Remove(dbEntry);
                context.SaveChanges();
            }  
        }

        public Branch GetById(long id)
        {
            return context.Branch.Where(x => x.BranchID == id).FirstOrDefault();
        }


    }
}
