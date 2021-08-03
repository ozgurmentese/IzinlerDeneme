using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelIzinDal : EfEntityRepositoryBase<PersonelIzin, IzinlerDenemeContext>, IPersonelIzinDal
    {
        public PersonelIzin IzinEkle(PersonelIzin personelIzin)
        {
            using (IzinlerDenemeContext context = new IzinlerDenemeContext())
            {
                var result = from personeller in context.Personeller
                             join personelIzinleri in context.PersonelIzinleri
                             on personeller.Id equals personelIzinleri.PersonelId
                             select new PersonelIzin
                             {
                                 PersonelId = personeller.Id,
                                 Gidis = personelIzinleri.Gidis,
                                 Donus = personelIzinleri.Donus,
                                 IzinGunSayisi = IzinGunuHesapla(DateTime.Now.Year - personeller.GirisTarihi.Year)
                             };
                return (PersonelIzin)result.FirstOrDefault();
            }
        }
        private static int IzinGunuHesapla(int girisTarihi)
        {
            if (girisTarihi > 1 && girisTarihi < 5)
            {
                return 14;
            }
            else if (girisTarihi > 5 && girisTarihi < 15)
            {
                return 20;
            }
            else if (girisTarihi >= 15)
            {
                return 26;
            }
            return 0;
        }
    }
}
