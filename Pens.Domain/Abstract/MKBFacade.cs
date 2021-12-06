using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
    public class MKBFacade
    {
        static MKBRepository mKBRepository = new MKBRepository();

        public static IEnumerable<MKB> GetByCategory(string category, int pageSize)
        {
            return GetByCategory(category, pageSize, 0);
        }

        public static IEnumerable<MKB> GetByCategory(string category, int pageSize, int page)
        {
            return mKBRepository.MKB.Where(x => x.TitleEn.Contains(category)).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static int GetCount(string category)
        {
            return mKBRepository.MKB.Where(x => x.TitleEn.Contains(category)).Count();
        }

        public static List<string> GetAlfabeta()
        {
            return mKBRepository.MKB.Select(x => x.TitleEn.Substring(0, 1)).Distinct().ToList();
        }
    }
}
