//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComtuterService.entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class GeneralTable
    {
        public int id { get; set; }
        public Nullable<int> orderid { get; set; }
        public Nullable<int> masterid { get; set; }
        public Nullable<int> clientid { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Masters Masters { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
