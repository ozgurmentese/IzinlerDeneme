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
    public class PersonelRaporManager : IPersonelRaporService
    {
        private readonly IPersonelRaporDal _personelRaporDal;

        public PersonelRaporManager(IPersonelRaporDal personelRaporDal)
        {
            _personelRaporDal = personelRaporDal;
        }

        public IResult Add(PersonelRapor personelRapor)
        {
            var personelrapor = _personelRaporDal.Get(p => p.Id == personelRapor.Id);
            var personelRaporGunSayisi = Convert.ToInt32((personelRapor.Donus - personelRapor.Gidis).TotalDays);
            var deger = personelrapor.KalanRaporGunSayisi - personelRaporGunSayisi;

            var result = BusinessRules.Run(
                           RaporGunuKontrol(personelrapor.KalanRaporGunSayisi),
                           RaporGunuKontrol(personelrapor.KalanRaporGunSayisi, personelRaporGunSayisi),
                           DegerKontrol(personelRaporGunSayisi),
                           DegerKontrol(personelrapor.KalanRaporGunSayisi)
                           );

            if (result != null)
            {
                return result;
            }

            var person = new PersonelRapor
            {
                PersonelId = personelRapor.PersonelId,
                HakEdilenRaporGunSayisi = personelrapor.HakEdilenRaporGunSayisi,
                TalepEdilenRaporGunSayisi = personelRaporGunSayisi,
                Donus = personelRapor.Donus,
                Gidis = personelRapor.Gidis,
                KalanRaporGunSayisi = deger
            };

            _personelRaporDal.Add(person);

            return new SuccessResult("Eklendi");
        }

        private IResult RaporGunuKontrol(int kalanRaporGunSayisi, int personelRaporGunSayisi = 0)
        {
            if (kalanRaporGunSayisi < personelRaporGunSayisi)
            {
                return new ErrorResult("İzin hatası");
            }
            return new SuccessResult();
        }

        private IResult DegerKontrol(int deger)
        {
            if (deger <= 0)
            {
                return new ErrorResult("Girilen tarih hatası");
            }
            return new SuccessResult();
        }

        public IDataResult<PersonelRapor> Get(int id)
        {
            return new SuccessDataResult<PersonelRapor>(_personelRaporDal.Get(p => p.Id == id), "Listelendi");
        }

        public IDataResult<List<PersonelRapor>> GetAll()
        {
            return new SuccessDataResult<List<PersonelRapor>>(_personelRaporDal.GetAll(), "Listelendi");
        }

        public IDataResult<List<PersonelRaporDto>> GetPersonelller()
        {
            return new SuccessDataResult<List<PersonelRaporDto>>(_personelRaporDal.GetPersoneller(), "Listelendi");
        }

        public IResult NewPersonelRaporAdd(Personel personel)
        {
            var result = DateTime.Now.Year - personel.GirisTarihi.Year;
            var rapor = RaporGunuHesapla(result);
            var personelRapor = new PersonelRapor
            {
                HakEdilenRaporGunSayisi = rapor,
                KalanRaporGunSayisi = rapor,
                PersonelId = personel.Id
            };

            _personelRaporDal.Add(personelRapor);

            return new SuccessResult("Eklendi");
        }

        public IResult Update(PersonelRapor personelRapor)
        {
            _personelRaporDal.Update(personelRapor);
            return new SuccessResult("Güncellendi");
        }

        private int RaporGunuHesapla(int girisTarihi)
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
    }
}
