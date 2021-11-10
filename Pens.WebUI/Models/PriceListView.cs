using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pens.WebUI.Models
{
    public class PriceListView
    {
        public IEnumerable<Price> Price { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}