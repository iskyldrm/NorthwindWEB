using Northwind.DAL.Abstract;
using Northwind.Entities.Models;

namespace Northwind.DAL.Concrete
{
    public class OrderDetailDal : RepositoryBase<OrderDetail>, IOrderDetailsDal
    {
    }
}
