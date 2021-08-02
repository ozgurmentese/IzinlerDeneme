using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PersonelIzinListe:IEntity
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public int IzinId { get; set; }
    }
}
