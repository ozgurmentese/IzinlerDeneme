using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class PersonelIzinDto:IDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public string AdSoyAd { get; set; }
        public int HakEdilenIzinGunSayisi { get; set; }
        public DateTime Gidis { get; set; }
        public DateTime Donus { get; set; }

        public int TalepEdilenIzinGunSayisi { get; set; }
        public int KalanIzinGunSayisi { get; set; }
    }
}
