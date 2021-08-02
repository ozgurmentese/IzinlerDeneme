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
        public List<PersonelDto> GetPersonel(Expression<Func<PersonelDto, bool>> filter = null)
        {
            using (IzinlerDenemeContext context = new IzinlerDenemeContext())
            {
                var result = from personeller in context.Personeller
                             join personelIzinListesi in context.PersonelIzinListesi
                             on personeller.Id equals personelIzinListesi.PersonelId
                             join personelIzinleri in context.PersonelIzinleri
                             on personelIzinListesi.IzinId equals personelIzinleri.Id
                             select new PersonelDto
                             {
                                 Ad = personeller.Ad,
                                 SoyAd = personeller.SoyAd,
                                 PersonelId = personeller.Id,
                                 IzinSayisi = personeller.IzinGunSayisi
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }


    }
}
