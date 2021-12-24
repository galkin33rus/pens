using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pens.WebUI.Models
{
    public class DocFilter
    {
        System.Globalization.DateTimeFormatInfo myDTFI = new System.Globalization.CultureInfo("ru-RU").DateTimeFormat;
        public DocFilter() {
            DateTime dt = DateTime.Now;
            if (this.DateFrom == null) { this.DateFrom = new DateTime(dt.Year, dt.Month, 1); }
            if (this.DateTo == null) { this.DateTo = ((DateTime)this.DateFrom).AddMonths(1).AddDays(-1); }
        }

        private String dateFromShortDateString;
        private String dateToShortDateString;

        public DateTime? DateFrom {get; set;}
        public DateTime? DateTo {get; set;}

        public String DateFromShortDateString { 
            get{ return ((DateTime)DateFrom).ToString(myDTFI.ShortDatePattern); }
            set { 
                dateFromShortDateString = value;
                DateFrom = DateTime.ParseExact(dateFromShortDateString, "dd.MM.yyyy", myDTFI);
            }
        }
        public String DateToShortDateString { 
            get{ return ((DateTime)DateTo).ToString(myDTFI.ShortDatePattern); }
            set
            {
                dateToShortDateString = value;
                DateTo = DateTime.ParseExact(dateToShortDateString, "dd.MM.yyyy", myDTFI);
            }
        }
        public long? BranchID { get; set; } 
    }
}