using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class PersonelRaporIzinDto:IDto
    {
        public int PersonelId { get; set; }
        public int IzinId { get; set; }
        public int RaporId { get; set; }
        public string AdSoyad { get; set; }
        public int IzinHakki { get; set; }
        public int KalanIzinHakki { get; set; }
        public int RaporHakki { get; set; }
        public int KalanRaporHakki { get; set; }
    }
}
