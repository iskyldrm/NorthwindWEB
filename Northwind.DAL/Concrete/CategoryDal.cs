using Northwind.DAL.Abstract;
using Northwind.Entities.Models;

namespace Northwind.DAL.Concrete
{
    public class CategoryDal : RepositoryBase<Category>, ICategoryDal
    {
    }
}
