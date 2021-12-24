using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Entities
{
    public partial class DocsMetaData
    {

        public long DocID { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Отделение")]
        public long BranchID { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]           
        [Display(Name = "Дата рождения")]
        public string DateBirth { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Display(Name = "Организация")]
        public string Org { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
        [Display(Name = "Документ")]
        public string Pasport { get; set; }
        [Display(Name = "Степень родства")]
        public string StRod { get; set; }
        [Display(Name = "ФИО родственника")]
        public string FIORod { get; set; }
        public System.DateTime Date { get; set; }       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Дата документа")]
        public Nullable<System.DateTime> DateDoc { get; set; }
        [Display(Name = "Номер трудовой книжки")]
        public string NoTK { get; set; }
        [Display(Name = "Код МКБ-10")]
        public string KodMKB { get; set; }
    }
}
