using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
    public class PriceFacade
    {
        static PriceRepository priceRepository = new PriceRepository();

        public static IEnumerable<Price> GetPrice()
        {
            return priceRepository.Price;
        }

        public static IEnumerable<Price> GetActivePrice()
        {
            return priceRepository.Price.Where(x => x.IsActive);
        }


        public static int GetTotalItems(string seachText)
        {
            return priceRepository.Price.Where(x => x.IsActive && (x.Title.ToUpper().Contains(seachText.ToUpper()) || x.Kod.StartsWith(seachText, StringComparison.OrdinalIgnoreCase))).Count();
        }

        public static IEnumerable<Price> GetSearchText(string seachText, int pageSize, int page)
        {
            return priceRepository.Price.Where(x => x.IsActive && (x.Title.ToUpper().Contains(seachText.ToUpper()) || x.Kod.StartsWith(seachText, StringComparison.OrdinalIgnoreCase))).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static Price GetById(long PriceId)
        {
            return priceRepository.GetById(PriceId);
        }

        public static void Save(Price price)
        {
            priceRepository.Save(price);
        }

        public static void Delete(long PriceID)
        {
            priceRepository.Delete(PriceID);
        }
    }
}
