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
    public class EfPersonelDal : EfEntityRepositoryBase<Personel, IzinlerDenemeContext>, IPersonelDal
    {
        public List<PersonelRaporIzinDto> PersonelRaporIzinList(Expression<Func<PersonelRaporIzinDto, bool>> filter = null)
        {
            using (var context = new IzinlerDenemeContext())
            {
                var result = from personeller in context.Personeller
                             join personelIzinleri in context.PersonelIzinleri
                             on personeller.Id equals personelIzinleri.PersonelId
                             join personelRaporlari in context.PersonelRaporlari
                             on personeller.Id equals personelRaporlari.PersonelId
                             select new PersonelRaporIzinDto
                             {
                                 PersonelId=personeller.Id,
                                 IzinId = personelIzinleri.Id,
                                 RaporId = personelRaporlari.Id,
                                 AdSoyad = personeller.Ad + " " + personeller.SoyAd,
                                 IzinHakki = personelIzinleri.HakEdilenIzinGunSayisi,
                                 KalanIzinHakki = personelIzinleri.KalanIzinGunSayisi,
                                 RaporHakki = personelRaporlari.HakEdilenRaporGunSayisi,
                                 KalanRaporHakki = personelRaporlari.KalanRaporGunSayisi
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
            //Full JOIN

            //using (var context = new IzinlerDenemeContext())
            //{
            //    var result = from personeller in context.Personeller
            //                 from personelIzinleri in context.PersonelIzinleri
            //                 from personelRaporlari in context.PersonelRaporlari
            //                 select new PersonelRaporIzinDto
            //                 {
            //                     IzinId = personelIzinleri.Id,
            //                     RaporId = personelRaporlari.Id,
            //                     AdSoyad = personeller.Ad + " " + personeller.SoyAd,
            //                     IzinHakki = personelIzinleri.HakEdilenIzinGunSayisi,
            //                     KalanIzinHakki = personelIzinleri.KalanIzinGunSayisi,
            //                     RaporHakkı = personelRaporlari.HakEdilenRaporGunSayisi,
            //                     KalanRaporHakkı = personelRaporlari.KalanRaporGunSayisi
            //                 };
            //    return filter == null ? result.ToList() : result.Where(filter).ToList();
            //}           
        }
    }
}
