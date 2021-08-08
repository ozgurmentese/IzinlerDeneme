using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelIzinDal : EfEntityRepositoryBase<PersonelIzin, IzinlerDenemeContext>, IPersonelIzinDal
    {
        public List<PersonelDto> GetPersoneller(Expression<Func<PersonelDto, bool>> filter = null)
        {

            using (IzinlerDenemeContext context = new IzinlerDenemeContext())
            {
                var result = from personeller in context.Personeller
                             join personelIzinleri in context.PersonelIzinleri
                             on personeller.Id equals personelIzinleri.PersonelId
                             select new PersonelDto
                             {
                                 Id = personelIzinleri.Id,
                                 AdSoyAd = personeller.Ad + " " + personeller.SoyAd,
                                 IzinGunSayisi = personelIzinleri.IzinGunSayisi,
                                 Gidis = personelIzinleri.Gidis,
                                 Donus = personelIzinleri.Donus
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
