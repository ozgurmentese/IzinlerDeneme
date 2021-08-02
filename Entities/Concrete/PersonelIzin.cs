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
        public int IzinRaporTuru { get; set; }
        public int IzinRaporTipi { get; set; }
        public DateTime IstekTarihi { get; set; }
        public int BelgeNo { get; set; }
    }
}
