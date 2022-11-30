using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Pens.Domain.Entities
{
    public partial class UsersMetaData
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Должность")]
        public string Position { get; set; }
                
        [Display(Name = "Отделение")]
        public Nullable<long> BranchId { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Роль")]
        public Int32 RoleId { get; set; }

    }
}
