using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(PersonelIzin personelIzin)
        {
            var personel = _personelIzinDal.Get(p => p.PersonelId == personelIzin.PersonelId);
            if (personel != null)
            {
                personel.IzinGunSayisi -= personelIzin.IzinGunSayisi;
                _personelIzinDal.Update(personel);
                return new SuccessResult("İzin Güncellendi");
            }
            else
            {
                _personelIzinDal.Add(personelIzin);
            }
            return new SuccessResult("Eklendi");
        }

        public IDataResult<PersonelIzin> Get(int id)
        {
            return new SuccessDataResult<PersonelIzin>(_personelIzinDal.Get(p => p.Id == id));
        }

        public IDataResult<List<PersonelIzin>> GetAll()
        {
            return new SuccessDataResult<List<PersonelIzin>>(_personelIzinDal.GetAll(), "Listelendi");
        }
    }
}
