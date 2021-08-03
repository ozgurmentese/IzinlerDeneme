using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PersonelIzin:IEntity
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public int IzinGunSayisi { get; set; }
        public DateTime Gidis { get; set; }
        public DateTime Donus { get; set; }
    }
}
