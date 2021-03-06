using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PersonelRapor:IEntity
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public int HakEdilenRaporGunSayisi { get; set; }
        public int TalepEdilenRaporGunSayisi { get; set; }
        public int KalanRaporGunSayisi { get; set; }
        public DateTime Gidis { get; set; }
        public DateTime Donus { get; set; }
    }
}
