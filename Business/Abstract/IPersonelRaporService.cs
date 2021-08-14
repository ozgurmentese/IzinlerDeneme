using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonelRaporService
    {
        IResult Add(PersonelRapor personelRapor);
        IResult Update(PersonelRapor personelRapor);
        IDataResult<List<PersonelRapor>> GetAll();
        IDataResult<PersonelRapor> Get(int id);
        IDataResult<List<PersonelRaporDto>> GetPersonelller();
        IResult NewPersonelRaporAdd(Personel personel);
    }
}
