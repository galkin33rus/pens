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
        private static DocsRepository docsRepository = new DocsRepository();

        public static List<Docs> GetDocs(DateTime? dateFrom, DateTime? dateTo, long branchId)
        {
            List<Docs> docStat = new List<Docs>();
            
            docStat = docsRepository.Docs.Where(x => x.DateDoc >= dateFrom && x.DateDoc <= dateTo && (x.BranchID == branchId)).ToList();

            return docStat;
        }

        public static IEnumerable<Docs> GetDocs(DateTime? dateFrom, DateTime? dateTo, long? branchId)
        {
            return docsRepository.Docs.Where(x => x.DateDoc >= dateFrom && x.DateDoc <= dateTo && (x.BranchID == branchId || branchId == null);
        }

        public static IEnumerable<Docs> GetDocs(DateTime? dateFrom, DateTime? dateTo)
        {
            return docsRepository.Docs.Where(x => x.DateDoc >= dateFrom && x.DateDoc <= dateTo);
        }

        public static Docs GetById(long docID)
        {
            return docsRepository.GetById(docID);
        }

        public static void Save(Docs doc)
        {
            docsRepository.Save(doc);
        }

        public static void Delete(long docId)
        {
            docsRepository.Delete(docId);
        }
    }
}
