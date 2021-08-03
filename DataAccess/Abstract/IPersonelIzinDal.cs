using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPersonelIzinDal:IEntityRepository<PersonelIzin>
    {
        PersonelIzin IzinEkle(PersonelIzin personelIzin);
    }
}
