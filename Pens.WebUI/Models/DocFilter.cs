using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pens.WebUI.Models
{
    public class DocFilter
    {
        public DocFilter() {
            DateTime dt = DateTime.Now;
            if (this.dateFrom == null) { this.dateFrom = new DateTime(dt.Year, dt.Month, 1); }
            if (this.dateTo == null) { this.dateTo = ((DateTime)this.dateFrom).AddMonths(1).AddDays(-1); }
        }

        public DateTime? dateFrom {get; set;}
        public DateTime? dateTo {get; set;}
        public long? BranchID { get; set; } 
    }
}