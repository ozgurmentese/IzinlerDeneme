using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class PersonelDto
    {
        public int Id { get; set; }
        public string AdSoyAd { get; set; }
        public int IzinGunSayisi { get; set; }
        public DateTime Gidis { get; set; }
        public DateTime Donus { get; set; }
    }
}
