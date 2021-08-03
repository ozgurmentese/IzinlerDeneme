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

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public IResult Add(Personel personel)
        {
            _personelDal.Add(personel);
            return new SuccessResult("Eklendi");
        }

        private int Hesapla(int izinGunSayisi)
        {
            if (izinGunSayisi > 1 && izinGunSayisi < 5)
            {
                return 14;
            }
            else if (izinGunSayisi > 5 && izinGunSayisi < 15)
            {
                return 20;
            }
            else if (izinGunSayisi >= 15)
            {
                return 26;
            }
            return 0;
        }

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
