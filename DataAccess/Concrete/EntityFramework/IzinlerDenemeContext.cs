using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class IzinlerDenemeContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HastaneBilgiYonetim;Trusted_Connection=true");
        }

        public DbSet<Personel> Personeller { get; set; }
        public DbSet<PersonelIzin> PersonelIzinleri { get; set; }
    }
}
