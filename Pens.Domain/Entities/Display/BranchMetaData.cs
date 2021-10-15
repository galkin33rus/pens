using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pens.Domain.Entities.Display
{
    
    public partial class BranchMetaData
    {
        public long BranchID { get; set; }

        [Display(Name = "Наименование")]
        public string Title { get; set; }
       
    }
}
