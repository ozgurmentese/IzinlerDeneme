using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PersonelIzinManager : IPersonelIzinService
    {
        IPersonelIzinDal _personelIzinDal;


        public PersonelIzinManager(IPersonelIzinDal personelIzinDal)
        {
            _personelIzinDal = personelIzinDal;


        }

        //public IResult Add(PersonelIzin personelIzin)
        //{

        //    var personelizin = _personelIzinDal.Get(p => p.PersonelId == personelIzin.PersonelId);
        //    var personel = _personelService.Get(personelIzin.PersonelId);


        //    var personelIzinGunSayisi = Convert.ToInt32((personelIzin.Donus - personelIzin.Gidis).TotalDays);

        //    if (personelIzinGunSayisi <= 0)
        //    {
        //        return new ErrorResult("Girilen tarih yanlıştır!");
        //    }
        //    if (personelizin != null)
        //    {
        //        if (personelizin.HakEdilenIzinGunSayisi < personelIzinGunSayisi)
        //        {
        //            return new ErrorResult("Geçersiz Tarih");
        //        }
        //        personelIzin.HakEdilenIzinGunSayisi = personelizin.HakEdilenIzinGunSayisi - personelIzinGunSayisi;
        //        _personelIzinDal.Update(personelIzin);
        //        return new SuccessResult("İzin Güncellendi");
        //    }


        //    _personelIzinDal.Add(personelIzin);

        //    return new SuccessResult("Eklendi");
        //}

        private int GunHesapla(DateTime gidis, DateTime donus)
        {
            DateTime geciciTarih = gidis;
            int gunSayi = 0;
            string gun = string.Empty;
            while (geciciTarih <= donus)
            {
                gun = geciciTarih.ToString("dddd");
                if (gun != "Cumartesi" && gun != "Pazar")
                {
                    gunSayi++;
                }
                geciciTarih = geciciTarih.AddDays(1);
            }
            return gunSayi;
        }


        public IResult Add(PersonelIzin personelIzin)
        {
            var personelizin = _personelIzinDal.Get(p => p.Id == personelIzin.Id);
            var personelIzinGunSayisi = GunHesapla(personelIzin.Gidis, personelIzin.Donus);
            var deger = personelizin.KalanIzinGunSayisi - personelIzinGunSayisi;

            var result = BusinessRules.Run(
                IzinGunuKontrol(personelizin.KalanIzinGunSayisi),
                IzinGunuKontrol(personelizin.KalanIzinGunSayisi, personelIzinGunSayisi),
                DegerKontrol(personelIzinGunSayisi),
                DegerKontrol(personelizin.KalanIzinGunSayisi)
                );

            if (result != null)
            {
                return result;
            }

            //if (personelizin.KalanIzinGunSayisi <= 0)
            //{
            //    return new ErrorResult("Personelin izin hakkı yoktur");
            //}

            //if (personelIzinGunSayisi <= 0)
            //{
            //    return new ErrorResult("Girilen tarih yanlıştır!");
            //}

            //if (personelizin.KalanIzinGunSayisi < personelIzinGunSayisi)
            //{
            //    return new ErrorResult("Geçersiz Tarih");
            //}

            //if (personelizin.KalanIzinGunSayisi <= 0)
            //{
            //    return new ErrorResult("İzin kalmadı");
            //}



            var person = new PersonelIzin
            {
                PersonelId = personelIzin.PersonelId,
                HakEdilenIzinGunSayisi = personelizin.HakEdilenIzinGunSayisi,
                TalepEdilenIzinGunSayisi = personelIzinGunSayisi,
                Donus = personelIzin.Donus,
                Gidis = personelIzin.Gidis,
                KalanIzinGunSayisi = deger
            };

            _personelIzinDal.Add(person);

            return new SuccessResult("Eklendi");
        }

        private IResult IzinGunuKontrol(int kalanIzinGunSayisi, int personelIzinGunSayisi = 0)
        {
            if (kalanIzinGunSayisi < personelIzinGunSayisi)
            {
                return new ErrorResult("İzin hatası");
            }
            return new SuccessResult();
        }

        private IResult DegerKontrol(int deger)
        {
            if (deger < 0)
            {
                return new ErrorResult("Girilen tarih hatası");
            }
            return new SuccessResult();
        }

        public IResult NewPersonelIzinAdd(Personel personel)
        {
            var result = DateTime.Now.Year - personel.GirisTarihi.Year;
            var izin = IzinGunuHesapla(result);
            var personelIzin = new PersonelIzin
            {
                HakEdilenIzinGunSayisi = izin,
                KalanIzinGunSayisi = izin,
                PersonelId = personel.Id
            };

            _personelIzinDal.Add(personelIzin);

            return new SuccessResult("Eklendi");

        }

        private int IzinGunuHesapla(int girisTarihi)
        {
            if (girisTarihi >= 1 && girisTarihi <= 5)
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

        public IDataResult<PersonelIzin> Get(int id)
        {
            return new SuccessDataResult<PersonelIzin>(_personelIzinDal.Get(p => p.Id == id));
        }

        public IDataResult<List<PersonelIzin>> GetAll()
        {
            return new SuccessDataResult<List<PersonelIzin>>(_personelIzinDal.GetAll(), "Listelendi");
        }

        public IDataResult<List<PersonelIzinDto>> GetPersonelller()
        {
            return new SuccessDataResult<List<PersonelIzinDto>>(_personelIzinDal.GetPersoneller(), "Listelendi");
        }

        public IResult Update(PersonelIzin personelIzin)
        {
            _personelIzinDal.Update(personelIzin);
            return new SuccessResult("Güncellendi");
        }
    }
}
