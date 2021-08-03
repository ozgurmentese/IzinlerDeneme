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
                             join personelIzinleri in context.PersonelIzinleri
                             on personeller.Id equals personelIzinleri.PersonelId
                             select new PersonelDto
                             {
                                 Ad = personeller.Ad,
                                 SoyAd = personeller.SoyAd,
                                 PersonelId = personeller.Id,
                                 IzinSayisi = personelIzinleri.IzinGunSayisi
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }

        }
    }
}
