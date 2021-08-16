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
    public class PersonelManager : IPersonelService
    {
        private readonly IPersonelDal _personelDal;
        private readonly IPersonelIzinService _personelIzinService;
        private readonly IPersonelRaporService _personelRaporService;

        public PersonelManager(IPersonelDal personelDal, IPersonelIzinService personelIzinService, IPersonelRaporService personelRaporService)
        {
            _personelDal = personelDal;
            _personelIzinService = personelIzinService;
            _personelRaporService = personelRaporService;
        }

        public IResult Add(Personel personel)
        {

            var personelIzin = _personelIzinService.NewPersonelIzinAdd(personel);
            var personelRapor = _personelRaporService.NewPersonelRaporAdd(personel);
            if (personelIzin.Success && personelRapor.Success)
            {
                _personelDal.Add(personel);
                return new SuccessResult("Eklendi");
            }
            return new ErrorResult("Hata Oluştu");
        }

        public IDataResult<Personel> Get(int id)
        {
            return new SuccessDataResult<Personel>(_personelDal.Get(p => p.Id == id), "Listelendi");
        }

        public IDataResult<List<Personel>> GetAll()
        {
            return new SuccessDataResult<List<Personel>>(_personelDal.GetAll(), "Listelendi");
        }

        public IDataResult<List<PersonelRaporIzinDto>> PersonelRaporIzinList()
        {
            return new SuccessDataResult<List<PersonelRaporIzinDto>>(_personelDal.PersonelRaporIzinList(), "Listelendi");
        }
    }
}
