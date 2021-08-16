using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        IResult Add(Personel personel);
        IDataResult<List<Personel>> GetAll();
        IDataResult<Personel> Get(int id);
        IDataResult<List<PersonelRaporIzinDto>> PersonelRaporIzinList();
       
    }
}
