using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Entities.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
        
    }
}