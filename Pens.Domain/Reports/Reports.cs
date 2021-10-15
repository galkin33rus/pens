using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Reports
{
    public class Reports
    {
        
        
        public static string Operativ(DateTime DateFrom, DateTime DateTo, Branch branch)
        {
            StringBuilder sb = new StringBuilder();
            DocsRepository docsRepository = new DocsRepository();
            IEnumerable<Docs> docs = docsRepository.Docs.Where(x => x.DateDoc >= DateFrom && x.DateDoc <= DateTo);
            if (branch != null && branch.BranchID > 0)
            {
                docs = docs.Where(x => x.BranchID == branch.BranchID);
            }
            int i=0;
            foreach(Docs doc in docs){
                
                foreach(Services service in doc.Services){
                    i++;
                    sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td><td>{12}</td></tr>",
                    i, doc.FIO, doc.DateBirth, doc.Pasport, doc.Org, doc.StRod, doc.FIORod, doc.NoTK, service.Title, service.Cost, service.CostR, service.Quantity, (service.Cost - service.CostR) * service.Quantity);                
                }
                

            }            
            return sb.ToString();
        }
    }
}
