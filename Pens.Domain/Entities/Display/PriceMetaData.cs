using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Pens.Domain.Entities
{
    
    public partial class PriceMetaData
    {        
        public long PriceID { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Код")]
        public string Kod { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Наименование")]
        public string Title { get; set; }
        [Display(Name = "Цена")]
        public Nullable<double> Cost { get; set; }
        [Display(Name = "Себистоимость")]
        public Nullable<double> CostR { get; set; }
        [Display(Name = "Отделение")]
        public Nullable<long> BranchID { get; set; }
                
    }
}
