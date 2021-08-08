using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPersonelDal:IEntityRepository<Personel>
    {
        //List<PersonelDto> GetPersonel(Expression<Func<PersonelDto, bool>> filter = null);
    }
}
