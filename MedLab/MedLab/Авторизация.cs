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
    
    public partial class Авторизация
    {
        public int Код_авторизации { get; set; }
        public Nullable<int> Код_пользователя { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public string IP_адрес { get; set; }
        public Nullable<System.DateTime> Дата_и_время_входа { get; set; }
        public Nullable<System.DateTime> Время_блокировки { get; set; }
    
        public virtual Пользователи Пользователи { get; set; }
    }
}
