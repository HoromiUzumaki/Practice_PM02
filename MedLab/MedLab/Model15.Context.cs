﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ЛабораторияEntities5 : DbContext
    {
        public ЛабораторияEntities5()
            : base("name=ЛабораторияEntities5")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Авторизация> Авторизация { get; set; }
        public virtual DbSet<Анализатор> Анализатор { get; set; }
        public virtual DbSet<Должность> Должность { get; set; }
        public virtual DbSet<Дополнительная_информация> Дополнительная_информация { get; set; }
        public virtual DbSet<Заказ> Заказ { get; set; }
        public virtual DbSet<Оказанные_услуги> Оказанные_услуги { get; set; }
        public virtual DbSet<Пользователи> Пользователи { get; set; }
        public virtual DbSet<Работа_анализатора> Работа_анализатора { get; set; }
        public virtual DbSet<Работа_с_биоматериалами> Работа_с_биоматериалами { get; set; }
        public virtual DbSet<Статус_заказа> Статус_заказа { get; set; }
        public virtual DbSet<Статус_услуги> Статус_услуги { get; set; }
        public virtual DbSet<Страховая_компания> Страховая_компания { get; set; }
        public virtual DbSet<Счета_страховым_компаниям> Счета_страховым_компаниям { get; set; }
        public virtual DbSet<Тип_страхового_полиса> Тип_страхового_полиса { get; set; }
        public virtual DbSet<Услуга> Услуга { get; set; }
    }
}