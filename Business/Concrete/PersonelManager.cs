using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;
        IPersonelIzinService _personelIzinService;
        IPersonelRaporService _personelRaporService;

        public PersonelManager(IPersonelDal personelDal,IPersonelIzinService personelIzinService,IPersonelRaporService personelRaporService)
        {
            _personelDal = personelDal;
            _personelIzinService = personelIzinService;
            _personelRaporService = personelRaporService;
        }

        //public IResult Add(Personel personel)
        //{
        //    _personelDal.Add(personel);
        //    PersonelIzin personelIzin = new PersonelIzin
        //    {
        //        PersonelId = personel.Id,
        //        HakEdilenIzinGunSayisi = Hesapla(DateTime.Now.Year - personel.GirisTarihi.Year)
        //    };

        //    _personelIzinDal.Add(personelIzin);
        //    return new SuccessResult("Eklendi");
        //}
        
        public IResult Add(Personel personel)
        {
            _personelDal.Add(personel);
            _personelIzinService.NewPersonelIzinAdd(personel);
            _personelRaporService.NewPersonelRaporAdd(personel);

            return new SuccessResult("Eklendi");
        }

        //private int Hesapla(int izinGunSayisi)
        //{
        //    if (izinGunSayisi >= 1 && izinGunSayisi <= 5)
        //    {
        //        return 14;
        //    }
        //    else if (izinGunSayisi > 5 && izinGunSayisi < 15)
        //    {
        //        return 20;
        //    }
        //    else if (izinGunSayisi >= 15)
        //    {
        //        return 26;
        //    }
        //    return 0;
        //}

        public IDataResult<Personel> Get(int id)
        {
            return new SuccessDataResult<Personel>(_personelDal.Get(p => p.Id == id), "Listelendi");
        }

        public IDataResult<List<Personel>> GetAll()
        {
            return new SuccessDataResult<List<Personel>>(_personelDal.GetAll(), "Listelendi");
        }
    }
}
