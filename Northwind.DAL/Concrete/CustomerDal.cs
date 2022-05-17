using Northwind.DAL.Abstract;
using Northwind.Entities.Models;

namespace Northwind.DAL.Concrete
{
    public class CustomerDal : RepositoryBase<Customer>, ICustomerDal
    {
    }
}
