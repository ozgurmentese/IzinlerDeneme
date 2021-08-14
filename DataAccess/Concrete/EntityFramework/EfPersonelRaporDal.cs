using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelRaporDal : EfEntityRepositoryBase<PersonelRapor, IzinlerDenemeContext>, IPersonelRaporDal
    {
        public List<PersonelRaporDto> GetPersoneller(Expression<Func<PersonelRaporDto, bool>> filter = null)
        {
            using (IzinlerDenemeContext context = new IzinlerDenemeContext())
            {
                var result = from personeller in context.Personeller
                             join personelRaporlari in context.PersonelRaporlari
                             on personeller.Id equals personelRaporlari.PersonelId
                             select new PersonelRaporDto
                             {
                                 PersonelId = personelRaporlari.Id,
                                 AdSoyAd = personeller.Ad + " " + personeller.SoyAd,
                                 HakEdilenRaporGunSayisi = personelRaporlari.HakEdilenRaporGunSayisi,
                                 KalanRaporGunSayisi = personelRaporlari.KalanRaporGunSayisi,
                                 TalepEdilenRaporGunSayisi = personelRaporlari.TalepEdilenRaporGunSayisi,
                                 Gidis = personelRaporlari.Gidis,
                                 Donus = personelRaporlari.Donus
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }



    }
}
