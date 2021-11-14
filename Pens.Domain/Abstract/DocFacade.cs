using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
    public class DocFacade
    {
        public static List<Docs> GetDocs(DateTime? dateFrom, DateTime? dateTo, long branchId)
        {
            List<Docs> docStat = new List<Docs>();
            DocsRepository docsRepository = new DocsRepository();

            docStat = docsRepository.Docs.Where(x => x.DateDoc >= dateFrom && x.DateDoc <= dateTo && (x.BranchID == branchId)).ToList();

            return docStat;
        }
    }
}
