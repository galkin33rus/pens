using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pens.WebUI.Models
{
    public class StatisticDoc
    {
        public string BranchTitle { get; set; }
        public double? NupPeople { get; set; }
        [DisplayFormat(DataFormatString = "{#.##:C}")]
        public double? SummPrice { get; set; }
        [DisplayFormat(DataFormatString = "{#.##:C}")]
        public double? SummSeb { get; set; }
        [DisplayFormat(DataFormatString = "{#.##:C}")]
        public double? SummDif { get; set; }
    }
}