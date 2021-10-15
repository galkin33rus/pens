using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Entities
{

    public partial class PacientMetaData
    {                
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]        
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true, NullDisplayText="")]
        public DateTime DateBirth { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Организация")]
        public string OrgID { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Должность")]
        public string PositionID { get; set; }
        [Display(Name = "Документ")]
        public string Pasport { get; set; }
        [Display(Name = "Степень родства")]
        public string StRodID { get; set; }
        [Display(Name = "ФИО родственника")]
        public string FIORod { get; set; }              
        [Display(Name = "Номер трудовой книжки")]
        public string NoTK { get; set; }
    }
}
