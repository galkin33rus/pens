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
    
    public partial class Services
    {
        public long ServiceID { get; set; }
        public long DocID { get; set; }
        public string Kod { get; set; }
        public string Title { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<double> CostR { get; set; }
        public Nullable<long> BranchID { get; set; }
        public long PriceID { get; set; }
        public int Quantity { get; set; }
    
        public virtual Docs Docs { get; set; }
    }
}