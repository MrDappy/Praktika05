﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Praktika05
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_HotelEntities2 : DbContext
    {
        public DB_HotelEntities2()
            : base("name=DB_HotelEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bron_num_hotel> Bron_num_hotel { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Inf_listok> Inf_listok { get; set; }
        public virtual DbSet<Nums_hotel> Nums_hotel { get; set; }
        public virtual DbSet<Oformlenie_poselenia> Oformlenie_poselenia { get; set; }
        public virtual DbSet<Status_clients> Status_clients { get; set; }
    }
}
