using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPersonelRaporDal:IEntityRepository<PersonelRapor>
    {
        List<PersonelRaporDto> GetPersoneller(Expression<Func<PersonelRaporDto, bool>> filter = null);
    }
}
