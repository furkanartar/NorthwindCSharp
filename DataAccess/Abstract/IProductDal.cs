using Entities.Concrete;
using System.Collections.Generic;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDTO> getProductDetails();
    }
}
