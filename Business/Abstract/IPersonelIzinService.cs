using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPersonelIzinService
    {
        IResult Add(PersonelIzin personelIzin);
        IDataResult<List<PersonelIzin>> GetAll();
        IDataResult<PersonelIzin> Get(int id);
    }
}
