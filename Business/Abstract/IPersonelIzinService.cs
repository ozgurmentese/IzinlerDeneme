using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPersonelIzinService
    {
        IResult Add(PersonelIzin personelIzin);
        IResult Update(PersonelIzin personelIzin);
        IDataResult<List<PersonelIzin>> GetAll();
        IDataResult<PersonelIzin> Get(int id);
        IDataResult<List<PersonelDto>> GetPersonelller();
    }
}
