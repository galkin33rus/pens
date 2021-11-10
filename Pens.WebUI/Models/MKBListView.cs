using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pens.WebUI.Models
{
    public class MKBListView
    {
        public IEnumerable<MKB> MKB { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}