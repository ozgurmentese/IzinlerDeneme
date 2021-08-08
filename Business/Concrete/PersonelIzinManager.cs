using Business.Abstract;
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
        IPersonelService _personelService;

        public PersonelIzinManager(IPersonelIzinDal personelIzinDal, IPersonelService personelService)
        {
            _personelIzinDal = personelIzinDal;
            _personelService = personelService;

        }

        public IResult Add(PersonelIzin personelIzin)
        {
            var personelizin = _personelIzinDal.Get(p => p.PersonelId == personelIzin.PersonelId);
            var personel = _personelService.Get(personelIzin.PersonelId);


            var izinGunSayisi = Convert.ToInt32((personelIzin.Donus - personelIzin.Gidis).TotalDays);
            if (personelizin != null)
            {
                if (personelizin.IzinGunSayisi < izinGunSayisi)
                {
                    return new ErrorResult("Geçersiz Tarih");
                }
                personelIzin.IzinGunSayisi= personelizin.IzinGunSayisi - izinGunSayisi;
                _personelIzinDal.Update(personelIzin);
                return new SuccessResult("İzin Güncellendi");
            }
            else
            {
                if (personel.Success)
                {
                    var result = personel.Data.GirisTarihi.Year;
                    personelIzin.IzinGunSayisi = IzinGunuHesapla(result);
                }

                _personelIzinDal.Add(personelIzin);
            }
            return new SuccessResult("Eklendi");
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

        public IDataResult<PersonelIzin> Get(int id)
        {
            return new SuccessDataResult<PersonelIzin>(_personelIzinDal.Get(p => p.Id == id));
        }

        public IDataResult<List<PersonelIzin>> GetAll()
        {
            return new SuccessDataResult<List<PersonelIzin>>(_personelIzinDal.GetAll(), "Listelendi");
        }

        public IDataResult<List<PersonelDto>> GetPersonelller()
        {
            return new SuccessDataResult<List<PersonelDto>>(_personelIzinDal.GetPersoneller(), "Listelendi");
        }

        public IResult Update(PersonelIzin personelIzin)
        {
            var result = Add(personelIzin);
            if (result.Success)
            {
                return new SuccessResult("Eklendi");
            }
            return new ErrorResult("Hata oluşu");
        }
    }
}
