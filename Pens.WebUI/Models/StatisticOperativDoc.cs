using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Pens.Domain.Entities;

namespace Pens.WebUI.Models
{
    public class StatisticOperativDoc
    {
        public string BranchTitle { get; set; }
        public double? NupPeople { get; set; }
        [DisplayFormat(DataFormatString = "{#.##:C}")]
        public double? SummPrice { get; set; }
        [DisplayFormat(DataFormatString = "{#.##:C}")]
        public double? SummSeb { get; set; }
        [DisplayFormat(DataFormatString = "{#.##:C}")]
        public double? SummDif { get; set; }
        public List<Docs> BranchDocs { get; set; }
    }
}