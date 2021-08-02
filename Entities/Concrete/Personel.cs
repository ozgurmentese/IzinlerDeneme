using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Personel:IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public DateTime GirisTarihi { get; set; }
        public int IzinGunSayisi { get; set; }
    }
}
