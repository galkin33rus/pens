//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pens.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Docs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Docs()
        {
            this.Services = new HashSet<Services>();
        }
    
        public long DocID { get; set; }
        public long BranchID { get; set; }
        public string FIO { get; set; }
        public string DateBirth { get; set; }
        public string Gender { get; set; }
        public string Org { get; set; }
        public string Position { get; set; }
        public string Pasport { get; set; }
        public string StRod { get; set; }
        public string FIORod { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<System.DateTime> DateDoc { get; set; }
        public string NoTK { get; set; }
        public string KodMKB { get; set; }
    
        public virtual Branch Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Services> Services { get; set; }
    }
}
