using Northwind.DAL.Abstract;
using Northwind.Entities.Models;

namespace Northwind.DAL.Concrete
{
    public class ProductDal : RepositoryBase<Product>, IProductDal
    {
    }
}
