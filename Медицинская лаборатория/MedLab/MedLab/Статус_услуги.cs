//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedLab
{
    using System;
    using System.Collections.Generic;
    
    public partial class Статус_услуги
    {
        public int Код_статуса_услуги { get; set; }
        public string Статус_услуги1 { get; set; }
        public Nullable<int> Код_услуги { get; set; }
    
        public virtual Услуга Услуга { get; set; }
    }
}
