using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IPersonelIzinDal:IEntityRepository<PersonelIzin>
    {
        List<PersonelIzinDto> GetPersoneller(Expression<Func<PersonelIzinDto, bool>> filter = null);
    }
}
